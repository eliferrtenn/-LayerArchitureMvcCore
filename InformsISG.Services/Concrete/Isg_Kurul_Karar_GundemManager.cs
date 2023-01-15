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
    public class Isg_Kurul_Karar_GundemManager : IISg_Kurul_Karar_GundemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Isg_Kurul_Karar_GundemManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Isg_Kurul_Karar_GundemDTO addObject, long createdByUserId)
        {
            //var exist = await _unitOfWork.isg_Kurul_Karar_GundemRepository.AnyAsync(x => x.Isg_Kurul_Karar_Id== addObject.Isg_Kurul_Karar_Id);
            //if (exist == false)
            //{
                var result = _mapper.Map<Isg_Kurul_Karar_Gundem>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.isg_Kurul_Karar_GundemRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Maddeler başarılı bir şekilde eklenmiştir.");
            //}
            //else
            //{
            //    return new Result(ResultStatus.Error, $"Maddeler zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            //}
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.isg_Kurul_Karar_GundemRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.isg_Kurul_Karar_GundemRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Madde başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Madde bulunamadı.");
        }

        public async Task<IDataResult<IList<Isg_Kurul_Karar_GundemDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.isg_Kurul_Karar_GundemRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Isg_Kurul_Karar_GundemDTO>>(resultObject);
                return new DataResult<IList<Isg_Kurul_Karar_GundemDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Isg_Kurul_Karar_GundemDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Isg_Kurul_Karar_GundemDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.isg_Kurul_Karar_GundemRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Isg_Kurul_Karar_GundemDTO>(resultObject);
                return new DataResult<Isg_Kurul_Karar_GundemDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Isg_Kurul_Karar_GundemDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.isg_Kurul_Karar_GundemRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                await _unitOfWork.isg_Kurul_Karar_GundemRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Gündem veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Gündem bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Isg_Kurul_Karar_GundemDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.isg_Kurul_Karar_GundemRepository.AnyAsync(x => x.Isg_Kurul_Karar_Id == updateObject.Isg_Kurul_Karar_Id && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.isg_Kurul_Karar_GundemRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Isg_Kurul_Karar_GundemDTO, Isg_Kurul_Karar_Gundem>(updateObject, resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.isg_Kurul_Karar_GundemRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, "Gündem başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, "Gündem bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, "Gündem zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
    }
}
