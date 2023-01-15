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
    public class Acil_Eylem_PlaniManager : IAcil_Eylem_PlaniService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Acil_Eylem_PlaniManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(Acil_Eylem_PlaniDTO addObject, long createdByUserId)
        {
        var exist = await _unitOfWork.acil_Eylem_PlaniRepository.AnyAsync(x => x.Plan_Adi == addObject.Plan_Adi && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Acil_Eylem_Plani>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.acil_Eylem_PlaniRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{addObject.Plan_Adi} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Plan_Adi} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.acil_Eylem_PlaniRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.acil_Eylem_PlaniRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Dosya} kişisi başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Dosya} kişisi bulunamadı.");
        }

        public async Task<IDataResult<IList<Acil_Eylem_PlaniDTO>>> GetAllAsync(long Id)
        {
            var resultObject = await _unitOfWork.acil_Eylem_PlaniRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.Birim_Id==Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Acil_Eylem_PlaniDTO>>(resultObject);
                return new DataResult<IList<Acil_Eylem_PlaniDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Acil_Eylem_PlaniDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Acil_Eylem_PlaniDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.acil_Eylem_PlaniRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Acil_Eylem_PlaniDTO>(resultObject);
                return new DataResult<Acil_Eylem_PlaniDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Acil_Eylem_PlaniDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.acil_Eylem_PlaniRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.acil_Eylem_PlaniRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Plan_Adi} acil eylem planı veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Plan_Adi} acil eylem planı bulunamadı.");
        }
    
        public async Task<IResult> UpdateAsync(Acil_Eylem_PlaniDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.acil_Eylem_PlaniRepository.AnyAsync(x => x.Plan_Adi == updateObject.Plan_Adi && !x.isDeleted && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.acil_Eylem_PlaniRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    DateTime dateTime = DateTime.Now;
                    var result = _mapper.Map<Acil_Eylem_PlaniDTO, Acil_Eylem_Plani>(updateObject, resultObject);
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.acil_Eylem_PlaniRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{updateObject.Plan_Adi} başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Plan_Adi} bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Plan_Adi} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }

        }
    }
}
