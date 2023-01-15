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
    public class Ortam_OlcumManager : IOrtam_OlcumService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Ortam_OlcumManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Ortam_OlcumDTO addObject, long createdByUserId)
        {
            //var exist =await _unitOfWork.ortam_OlcumRepository.AnyAsync(x => x. == addObject.Tali_Birim_Id);
            //if (exist == false)
            //{
                var result = _mapper.Map<Ortam_Olcum>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.ortam_OlcumRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Ortam ölçümü başarılı bir şekilde eklenmiştir.");
            //}
            //else
            //{
            //    return new Result(ResultStatus.Error, $"Ortam Ölçümü ölçümü zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            //}
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.ortam_OlcumRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.ortam_OlcumRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Ortam Ölçümü başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Tali_Birim.Tali_Birim_Ad} ölçümü  bulunamadı.");
        }

        public async Task<IDataResult<IList<Ortam_OlcumDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.ortam_OlcumRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Ortam_OlcumDTO>>(resultObject);
                return new DataResult<IList<Ortam_OlcumDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Ortam_OlcumDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Ortam_OlcumDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.ortam_OlcumRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Ortam_OlcumDTO>(resultObject);
                return new DataResult<Ortam_OlcumDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Ortam_OlcumDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.ortam_OlcumRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                await _unitOfWork.ortam_OlcumRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Ortam ölçümü veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Ortam ölçümü  bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Ortam_OlcumDTO updateObject, long modifiedByUserId)
        {
            //var exist = await _unitOfWork.ortam_OlcumRepository.AnyAsync(x => x.Tali_Birim_Id == updateObject.Tali_Birim_Id && x.Id != updateObject.Id);
            //if (exist == false)
            //{
                var resultObject = await _unitOfWork.ortam_OlcumRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Ortam_OlcumDTO,Ortam_Olcum>(updateObject,resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.ortam_OlcumRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, "Ortam ölçümü başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, "Ortam ölçümü bulunamadı.");
                }
            //}
            //else
            //{
            //    return new Result(ResultStatus.Error, $"{updateObject.Tali_Birim_Id} ölçümü zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            //}
        }
    }
}
