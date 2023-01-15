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
    public class Egitim_Tanim_KonuManager : IEgitim_Tanim_KonuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Egitim_Tanim_KonuManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Egitim_Tanim_KonuDTO addObject, long createdByUserId)
        {

                var result = _mapper.Map<Egitim_Tanim_Konu>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.egitim_Tanim_KonuRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success , "Başarılı bir şekilde eklenmiştir.");
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.egitim_Tanim_KonuRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.egitim_Tanim_KonuRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Veri bulunamadı.");
        }

        public async Task<IDataResult<IList<Egitim_Tanim_KonuDTO>>> GetAllAsync(long Id)
        {
            var resultObject = await _unitOfWork.egitim_Tanim_KonuRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Egitim_Tanim_KonuDTO>>(resultObject);
                return new DataResult<IList<Egitim_Tanim_KonuDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Egitim_Tanim_KonuDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }


        public async Task<IDataResult<IList<Egitim_Tanim_KonuDTO>>> GetEgitimAsync(long Id)
        {
            var resultObject = await _unitOfWork.egitim_Tanim_KonuRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.Egitim_Tanimla_Id==Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Egitim_Tanim_KonuDTO>>(resultObject);
                return new DataResult<IList<Egitim_Tanim_KonuDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Egitim_Tanim_KonuDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }


        
        public async Task<IDataResult<IList<Egitim_Tanim_KonuDTO>>> GetKonuAltAsync(long Id)
        {
            var resultObject = await _unitOfWork.egitim_Tanim_KonuRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.Egitim_Konu_Alt_Baslik_Id==Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Egitim_Tanim_KonuDTO>>(resultObject);
                return new DataResult<IList<Egitim_Tanim_KonuDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Egitim_Tanim_KonuDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }



    }


}
