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
    public class Isg_Kurul_Karar2Manager : IIsg_Kurul_Karar2Service
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Isg_Kurul_Karar2Manager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Isg_Kurul_Karar2DTO addObject, long createdByUserId)
        {

            var exist = await _unitOfWork.isg_Kurul_Karar2Repository.AnyAsync(x => x.Karar_No == addObject.Karar_No && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Isg_Kurul_Karar2>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.isg_Kurul_Karar2Repository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{addObject.Karar_No} numaralı karar başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Karar_No} numaralı karar zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.isg_Kurul_Karar2Repository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.isg_Kurul_Karar2Repository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Karar_No} numaralı karar başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Karar_No} numaralı karar bulunamadı.");
        }

        public async Task<IDataResult<IList<Isg_Kurul_Karar2DTO>>> GetAllAsync()
        {

            var resultObject = await _unitOfWork.isg_Kurul_Karar2Repository.GetAllAsync(x => x.isActive && !x.isDeleted);

            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Isg_Kurul_Karar2DTO>>(resultObject);
                return new DataResult<IList<Isg_Kurul_Karar2DTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Isg_Kurul_Karar2DTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Isg_Kurul_Karar2DTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.isg_Kurul_Karar2Repository.GetAsync(x => x.Id == Id);

            if (resultObject != null)
            {
                var result = _mapper.Map<Isg_Kurul_Karar2DTO>(resultObject);
                return new DataResult<Isg_Kurul_Karar2DTO>(ResultStatus.Success, result);
            }
            return new DataResult<Isg_Kurul_Karar2DTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.isg_Kurul_Karar2Repository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.isg_Kurul_Karar2Repository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Karar_No} numaralı karar veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Karar_No} numaralı karar bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Isg_Kurul_Karar2DTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.isg_Kurul_Karar2Repository.AnyAsync(x => x.Karar_No == updateObject.Karar_No && !x.isDeleted && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.isg_Kurul_Karar2Repository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    DateTime dateTime = DateTime.Now;
                    var result = _mapper.Map<Isg_Kurul_Karar2DTO, Isg_Kurul_Karar2>(updateObject, resultObject);
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.isg_Kurul_Karar2Repository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{updateObject.Karar_No} numaralı karar başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Karar_No} numaralı karar bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Karar_No} numaralı karar zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }

        }


        public async Task<IDataResult<IList<Isg_Kurul_Karar2DTO>>> GetKurulToplanti(long Id)
        {

            var resultObject = await _unitOfWork.isg_Kurul_Karar2Repository.GetAllAsync(x => x.isActive && !x.isDeleted && x.Isg_Kurul_Karar_Id==Id);

            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Isg_Kurul_Karar2DTO>>(resultObject);
                return new DataResult<IList<Isg_Kurul_Karar2DTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Isg_Kurul_Karar2DTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }
    }
}
