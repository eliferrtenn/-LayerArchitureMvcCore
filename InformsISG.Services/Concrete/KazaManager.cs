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
    public class KazaManager : IKazaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public KazaManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(KazaDTO addObject, long createdByUserId)
        {
            var exist = await _unitOfWork.kazaRepository.AnyAsync(x => x.Kaza_No == addObject.Kaza_No);
            if (exist == false)
            {
                var result = _mapper.Map<Kaza>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.kazaRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Kaza_No} numaralı kaza başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Kaza_No} numaralı kaza zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
        public async Task<IDataResult<KazaDTO>> AddAndGetAsync(KazaDTO addObject, long createdByUserId)
        {
            var exist = await _unitOfWork.kazaRepository.AnyAsync(x => x.Kaza_No == addObject.Kaza_No);
            if (exist == false)
            {
                var result = _mapper.Map<Kaza>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.kazaRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                var result1 = _mapper.Map<KazaDTO>(result);

                return new DataResult<KazaDTO>(ResultStatus.Success, result1);
            }
            else
            {
                return new DataResult<KazaDTO>(ResultStatus.Error, "Veri zaten kayıtlıdır. Lütfen tekrar deneyiniz",
            null);
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.kazaRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.kazaRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Kaza_No} numaralı kaza başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Kaza_No} numaralı kaza bulunamadı.");
        }

        public async Task<IDataResult<IList<KazaDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.kazaRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<KazaDTO>>(resultObject);
                return new DataResult<IList<KazaDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<KazaDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<KazaDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.kazaRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<KazaDTO>(resultObject);
                return new DataResult<KazaDTO>(ResultStatus.Success, result);
            }
            return new DataResult<KazaDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.kazaRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.kazaRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Kaza_No} numaralı kaza veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Kaza_No} numaralı kaza bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(KazaDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.kazaRepository.AnyAsync(x => x.Kaza_No == updateObject.Kaza_No  && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.kazaRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<KazaDTO,Kaza>(updateObject,resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.kazaRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Kaza_No} numaralı kaza başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Kaza_No} numaralı kaza bulunamadı.");
            }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Kaza_No} numaralı kaza zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }



        public async Task<IDataResult<IList<KazaDTO>>> GetAllKazaAsync(long Id)
        {
            var resultObject = await _unitOfWork.kazaRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.Personel_Id==Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<KazaDTO>>(resultObject);
                return new DataResult<IList<KazaDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<KazaDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }



    }
}
