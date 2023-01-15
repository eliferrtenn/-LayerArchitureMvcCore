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
    public class Acil_Durum_Ekip_PersonelManager : IAcil_Durum_Ekip_PersonelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Acil_Durum_Ekip_PersonelManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Acil_Durum_Ekip_PersonelDTO addObject, long createdByUserId)
        {
            var exist = await _unitOfWork.acil_Durum_Ekip_PersonelRepository.AnyAsync(x => x.Personel_Id == addObject.Personel_Id && !x.isDeleted
            &&  x.Ekip_Id == addObject.Ekip_Id);
            if (exist == false)
            {
                var result = _mapper.Map<Acil_Durum_Ekip_Personel>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.acil_Durum_Ekip_PersonelRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Acil Durum Ekip personeli başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"Acil Durum Ekip personeli zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.acil_Durum_Ekip_PersonelRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.acil_Durum_Ekip_PersonelRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Acil Durum Ekip personeli başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Acil Durum Ekip personeli bulunamadı.");
        }

        public async Task<IDataResult<IList<Acil_Durum_Ekip_PersonelDTO>>> GetAllAsync(long Id)
        {
            var resultObject = await _unitOfWork.acil_Durum_Ekip_PersonelRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.Birim_Id==Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Acil_Durum_Ekip_PersonelDTO>>(resultObject);
                return new DataResult<IList<Acil_Durum_Ekip_PersonelDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Acil_Durum_Ekip_PersonelDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<IList<Acil_Durum_Ekip_PersonelDTO>>> GetBirimAsync(long Id)
        {
            var resultObject = await _unitOfWork.acil_Durum_Ekip_PersonelRepository.GetAllAsync(x => x.Birim_Id==Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Acil_Durum_Ekip_PersonelDTO>>(resultObject);
                return new DataResult<IList<Acil_Durum_Ekip_PersonelDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Acil_Durum_Ekip_PersonelDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }
       
        public async Task<IDataResult<IList<Acil_Durum_Ekip_PersonelDTO>>> GetEkip(long Id)
        {
            var resultObject = await _unitOfWork.acil_Durum_Ekip_PersonelRepository.GetAllAsync(x => x.Ekip_Id == Id);
            if (resultObject.Count > -1)
            {
                var result = _mapper.Map<IList<Acil_Durum_Ekip_PersonelDTO>>(resultObject);

                return new DataResult<IList<Acil_Durum_Ekip_PersonelDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Acil_Durum_Ekip_PersonelDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı.", null);
        }

        public async Task<IDataResult<Acil_Durum_Ekip_PersonelDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.acil_Durum_Ekip_PersonelRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Acil_Durum_Ekip_PersonelDTO>(resultObject);
                return new DataResult<Acil_Durum_Ekip_PersonelDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Acil_Durum_Ekip_PersonelDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.acil_Durum_Ekip_PersonelRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.acil_Durum_Ekip_PersonelRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Acil Durum Ekip personeli veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Acil Durum Ekip personeli bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Acil_Durum_Ekip_PersonelDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.acil_Durum_Ekip_PersonelRepository.AnyAsync(x => x.Personel_Id == updateObject.Personel_Id && !x.isDeleted
            && x.Ekip_Id == updateObject.Ekip_Id && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.acil_Durum_Ekip_PersonelRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Acil_Durum_Ekip_PersonelDTO,Acil_Durum_Ekip_Personel>(updateObject,resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime; 
                    await _unitOfWork.acil_Durum_Ekip_PersonelRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{resultObject.Ekip_Lideri} kişisi başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{resultObject.Ekip_Lideri} kişisi bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"Acil Durum Ekip personeli zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
    }

}
