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
    public class DofManager : IDofService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DofManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(DofDTO addObject, long createdByUserId)
        {
            bool exist =await _unitOfWork.dofRepository.AnyAsync(x => x.Dof_No == addObject.Dof_No);
            if (exist == false)
            {
                var result = _mapper.Map<Dof>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.dofRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Dof_No} numaralı DÖF başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Dof_No} numaralı DÖF zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.dofRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.dofRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Dof_Ad} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Dof_Ad} bulunamadı.");
        }

        public async Task<IDataResult<IList<DofDTO>>> GetAllAsync(long Id)
        {
            var resultObject = await _unitOfWork.dofRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.Birim_Id==Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<DofDTO>>(resultObject);
                return new DataResult<IList<DofDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<DofDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<DofDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.dofRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<DofDTO>(resultObject);
                return new DataResult<DofDTO>(ResultStatus.Success, result);
            }
            return new DataResult<DofDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.dofRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.dofRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Dof_Ad} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Dof_Ad} bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(DofDTO updateObject, long modifiedByUserId)
        {
            bool exist = await _unitOfWork.dofRepository.AnyAsync(x => x.Dof_No == updateObject.Dof_No && x.Id != updateObject.Id && !x.isDeleted);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.dofRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<DofDTO,Dof>(updateObject,resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.dofRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Dof_No} numaralı DÖF başarılı bir şekilde güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Dof_No} numaralı DÖF bulunamadı.");
            }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Dof_No} numaralı DÖF zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }


        public async Task<IDataResult<DofDTO>> GetDofNoAsync(long Id)
        {

            var resultObject = await _unitOfWork.dofRepository.GetAsync(x => x.Dof_No == Convert.ToString(Id));
            if (resultObject != null)
            {
                var result = _mapper.Map<DofDTO>(resultObject);
                return new DataResult<DofDTO>(ResultStatus.Success, result);
            }
            return new DataResult<DofDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

    }
}
