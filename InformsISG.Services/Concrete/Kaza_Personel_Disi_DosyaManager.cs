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
    public class Kaza_Personel_Disi_DosyaManager : IKaza_Personel_Disi_DosyaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Kaza_Personel_Disi_DosyaManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Kaza_Personel_Disi_DosyaDTO addObject, long createdByUserId)
        {
            var exist =await  _unitOfWork.kaza_Personel_Disi_DosyaRepository.AnyAsync(x => x.Kaza_Personel_Disi_Id == addObject.Kaza_Personel_Disi_Id);
            if (exist == false)
            {
                var result = _mapper.Map<Kaza_Personel_Disi_Dosya>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.kaza_Personel_Disi_DosyaRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Dosya başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"Dosya zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.kaza_Personel_Disi_DosyaRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.kaza_Personel_Disi_DosyaRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Dosya başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Dosya bulunamadı.");
        }

        public async Task<IDataResult<IList<Kaza_Personel_Disi_DosyaDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.kaza_Personel_Disi_DosyaRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Kaza_Personel_Disi_DosyaDTO>>(resultObject);
                return new DataResult<IList<Kaza_Personel_Disi_DosyaDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Kaza_Personel_Disi_DosyaDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Kaza_Personel_Disi_DosyaDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.kaza_Personel_Disi_DosyaRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Kaza_Personel_Disi_DosyaDTO>(resultObject);
                return new DataResult<Kaza_Personel_Disi_DosyaDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Kaza_Personel_Disi_DosyaDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.kaza_Personel_Disi_DosyaRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.kaza_Personel_Disi_DosyaRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Dosya veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Dosya bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Kaza_Personel_Disi_DosyaDTO updateObject, long modifiedByUserId)
        {
            var exist =await _unitOfWork.kaza_Personel_Disi_DosyaRepository.AnyAsync(x => x.Kaza_Personel_Disi_Id == updateObject.Kaza_Personel_Disi_Id && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.kaza_Personel_Disi_DosyaRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Kaza_Personel_Disi_DosyaDTO,Kaza_Personel_Disi_Dosya>(updateObject,resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.kaza_Personel_Disi_DosyaRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Dosya başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"Dosya bulunamadı.");
            }
            }
            else
            {
                return new Result(ResultStatus.Error, $"Dosya zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
    }
}
