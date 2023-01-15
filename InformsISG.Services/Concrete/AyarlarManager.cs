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
    public class AyarlarManager : IAyarlarService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AyarlarManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<IResult> AddAsync(AyarlarDTO addObject, long createdByUserId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<IList<AyarlarDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.ayarlarRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<AyarlarDTO>>(resultObject);
                return new DataResult<IList<AyarlarDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<AyarlarDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<AyarlarDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.ayarlarRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<AyarlarDTO>(resultObject);
                return new DataResult<AyarlarDTO>(ResultStatus.Success, result);
            }
            return new DataResult<AyarlarDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public Task<IResult> HardDeleteAsync(long Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> UpdateAsync(AyarlarDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.ayarlarRepository.AnyAsync(x => x.Tehlike_Tip == updateObject.Tehlike_Tip && x.Id != updateObject.Id);
            if (exist == false)
            {
             var resultObject = await _unitOfWork.ayarlarRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                 var result = _mapper.Map<AyarlarDTO, Ayarlar>(updateObject, resultObject);
                DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.ayarlarRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Tehlike_Tip} başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Tehlike_Tip} bulunamadı.");
            }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Tehlike_Tip} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
        }
    }
