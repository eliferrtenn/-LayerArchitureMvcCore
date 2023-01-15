using AutoMapper;
using InformsISG.Core.Utilities.Results;
using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Core.Utilities.Results.Concrete;
using InformsISG.Data.Abstract;
using InformsISG.Entities.Concrete;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace InformsISG.Services.Concrete
{
    public class MuayeneManager : IMuayeneService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MuayeneManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(MuayeneDTO addObject, long createdByUserId)
        {

                var result = _mapper.Map<Muayene>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.muayeneRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Kişinin muayenesi başarılı bir şekilde eklenmiştir.");

        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.muayeneRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.muayeneRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Personel_Bilgi.Ad_Soyad} kişisinin muayenesi başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Personel_Bilgi.Ad_Soyad} kişisinin muayenesibulunamadı.");
        }

        public async Task<IDataResult<IList<MuayeneDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.muayeneRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<MuayeneDTO>>(resultObject);
                return new DataResult<IList<MuayeneDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<MuayeneDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }
      
        
        public async Task<IDataResult<IList<MuayeneDTO>>> GetAllPersonelAsync()
        {
            var resultObject = await _unitOfWork.muayeneRepository.GetAllAsync(x => x.isActive && !x.isDeleted );
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<MuayeneDTO>>(resultObject);
                return new DataResult<IList<MuayeneDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<MuayeneDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<MuayeneDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.muayeneRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<MuayeneDTO>(resultObject);
                return new DataResult<MuayeneDTO>(ResultStatus.Success, result);
            }
            return new DataResult<MuayeneDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.muayeneRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                await _unitOfWork.muayeneRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Personel_Bilgi.Ad_Soyad} kişisinin muayenesi veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Personel_Bilgi.Ad_Soyad} kişisinin muayenesi bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(MuayeneDTO updateObject, long modifiedByUserId)
        {

                var resultObject = await _unitOfWork.muayeneRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<MuayeneDTO,Muayene>(updateObject,resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.muayeneRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Personel_Bilgi.Ad_Soyad} kişisinin muayenesi başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Personel_Id} kişisinin muayenesi bulunamadı.");
                }
        }

        public async Task<IDataResult<IList<MuayeneDTO>>> GetAllChoosePersonelAsync(long Id)
        {
            var resultObject = await _unitOfWork.muayeneRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.Personel_Id==Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<MuayeneDTO>>(resultObject);
                return new DataResult<IList<MuayeneDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<MuayeneDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }
    }
}
