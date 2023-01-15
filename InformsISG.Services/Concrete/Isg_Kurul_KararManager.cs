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
    public class Isg_Kurul_KararManager : IISg_Kurul_KararService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Isg_Kurul_KararManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(Isg_Kurul_KararDTO addObject, long createdByUserId)
        {
            var exist = await _unitOfWork.isg_Kurul_KararRepository.AnyAsync(x => x.Toplanti_No == addObject.Toplanti_No && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Isg_Kurul_Karar>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.isg_Kurul_KararRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Toplanti_No} numaralı kurul kararı başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Toplanti_No} numaralı kurul kararı zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.isg_Kurul_KararRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.isg_Kurul_KararRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Toplanti_No} numaralı kurul kararı başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Toplanti_No} numaralı kurul kararı bulunamadı.");
        }

        public async Task<IDataResult<IList<Isg_Kurul_KararDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.isg_Kurul_KararRepository.GetAllAsync(x => x.isActive && !x.isDeleted );
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Isg_Kurul_KararDTO>>(resultObject);
                return new DataResult<IList<Isg_Kurul_KararDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Isg_Kurul_KararDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }
      
        
        public async Task<IDataResult<IList<Isg_Kurul_KararDTO>>> GetAllDesAsync()
        {
            var resultObject = await _unitOfWork.isg_Kurul_KararRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Isg_Kurul_KararDTO>>(resultObject);
                return new DataResult<IList<Isg_Kurul_KararDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Isg_Kurul_KararDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Isg_Kurul_KararDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.isg_Kurul_KararRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Isg_Kurul_KararDTO>(resultObject);
                return new DataResult<Isg_Kurul_KararDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Isg_Kurul_KararDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.isg_Kurul_KararRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                await _unitOfWork.isg_Kurul_KararRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Toplanti_No} numaralı kurul kararı veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Toplanti_No} numaralı kurul kararı bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Isg_Kurul_KararDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.isg_Kurul_KararRepository.AnyAsync(x => x.Toplanti_No == updateObject.Toplanti_No && !x.isDeleted
            && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.isg_Kurul_KararRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Isg_Kurul_KararDTO,Isg_Kurul_Karar>(updateObject,resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.isg_Kurul_KararRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Toplanti_No} numaralı kurul kararı başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Toplanti_No} numaralı kuruş kararı bulunamadı.");
            }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Toplanti_No} numaralı kurul kararı zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }






    }
}
