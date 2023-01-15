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
    public class Makine_Ekipman_Bakim_FotografManager : IMakine_Ekipman_Bakim_FotografService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Makine_Ekipman_Bakim_FotografManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Makine_Ekipman_Bakim_FotografDTO addObject, long createdByUserId)
        {
            var result = _mapper.Map<Makine_Ekipman_Bakim_Fotograf>(addObject);
            DateTime dateTime = DateTime.Now;
            result.Kullanici_Id = createdByUserId;
            result.Yaratilma_Tarihi = dateTime;
            result.Degistirilme_Tarihi = dateTime;
            await _unitOfWork.makine_Ekipman_Bakim_FotografRepository.AddAsync(result);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, "Fotograf başarılı bir şekilde eklenmiştir.");

        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.makine_Ekipman_Bakim_FotografRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.makine_Ekipman_Bakim_FotografRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Fotoğraf başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Fotoğraf planı bulunamadı.");
        }

        public async Task<IDataResult<IList<Makine_Ekipman_Bakim_FotografDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.makine_Ekipman_Bakim_PlanlariRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Makine_Ekipman_Bakim_FotografDTO>>(resultObject);
                return new DataResult<IList<Makine_Ekipman_Bakim_FotografDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Makine_Ekipman_Bakim_FotografDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }
        public async Task<IDataResult<IList<Makine_Ekipman_Bakim_FotografDTO>>> GetEkipman(long Id)
        {
            var resultObject = await _unitOfWork.makine_Ekipman_Bakim_PlanlariRepository.GetAllAsync(x => x.Makine_Ekipman_Id == Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Makine_Ekipman_Bakim_FotografDTO>>(resultObject);
                return new DataResult<IList<Makine_Ekipman_Bakim_FotografDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Makine_Ekipman_Bakim_FotografDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Makine_Ekipman_Bakim_FotografDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.makine_Ekipman_Bakim_FotografRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Makine_Ekipman_Bakim_FotografDTO>(resultObject);
                return new DataResult<Makine_Ekipman_Bakim_FotografDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Makine_Ekipman_Bakim_FotografDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.makine_Ekipman_Bakim_PlanlariRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.makine_Ekipman_Bakim_PlanlariRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Fotoğraf veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Fotoğraf bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Makine_Ekipman_Bakim_FotografDTO updateObject, long modifiedByUserId)
        {

            var resultObject = await _unitOfWork.makine_Ekipman_Bakim_FotografRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Makine_Ekipman_Bakim_FotografDTO, Makine_Ekipman_Bakim_Fotograf>(updateObject, resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.makine_Ekipman_Bakim_FotografRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Fotoğraf başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, "Fotoğraf bulunamadı.");
            }


        }

        public async Task<IDataResult<IList<Makine_Ekipman_Bakim_FotografDTO>>> GetFoto(long Id)
        {
            var resultObject = await _unitOfWork.makine_Ekipman_Bakim_FotografRepository.GetAllAsync(x => x.Makine_Ekipman_Bakim_Planlari_Id==Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Makine_Ekipman_Bakim_FotografDTO>>(resultObject);
                return new DataResult<IList<Makine_Ekipman_Bakim_FotografDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Makine_Ekipman_Bakim_FotografDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }
    }
}
