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
    public class Makine_Ekipman_Bakim_PlanlariManager : IMakine_Ekipman_Bakim_PlanlariService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Makine_Ekipman_Bakim_PlanlariManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
 
        public async Task<IResult> AddAsync(Makine_Ekipman_Bakim_PlanlariDTO addObject, long createdByUserId)
        {
                var result = _mapper.Map<Makine_Ekipman_Bakim_Planlari>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.makine_Ekipman_Bakim_PlanlariRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Bakım planı başarılı bir şekilde eklenmiştir.");
        }

        public async Task<IDataResult<Makine_Ekipman_Bakim_PlanlariDTO>> AddAndGetAsync(Makine_Ekipman_Bakim_PlanlariDTO addObject, long createdByUserId)
        {
                var result = _mapper.Map<Makine_Ekipman_Bakim_Planlari>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.makine_Ekipman_Bakim_PlanlariRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                var result1 = _mapper.Map<Makine_Ekipman_Bakim_PlanlariDTO>(result);
                return new DataResult<Makine_Ekipman_Bakim_PlanlariDTO>(ResultStatus.Success, result1);
            
        }
        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.makine_Ekipman_Bakim_PlanlariRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.makine_Ekipman_Bakim_PlanlariRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Bakım planı başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Bakım planı bulunamadı.");
        }

        public async Task<IDataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.makine_Ekipman_Bakim_PlanlariRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Makine_Ekipman_Bakim_PlanlariDTO>>(resultObject);
                return new DataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }


        public async Task<IDataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>> GetBeklemeAsync()
        {
            var resultObject = await _unitOfWork.makine_Ekipman_Bakim_PlanlariRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.OnayBirimSorumlu==0 || x.OnayIsgUzman==0);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Makine_Ekipman_Bakim_PlanlariDTO>>(resultObject);
                return new DataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>> GetEkipman(long Id)
        {
            var resultObject = await _unitOfWork.makine_Ekipman_Bakim_PlanlariRepository.GetAllAsync(x => x.Makine_Ekipman_Id==Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Makine_Ekipman_Bakim_PlanlariDTO>>(resultObject);
                return new DataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Makine_Ekipman_Bakim_PlanlariDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.makine_Ekipman_Bakim_PlanlariRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Makine_Ekipman_Bakim_PlanlariDTO>(resultObject);
                return new DataResult<Makine_Ekipman_Bakim_PlanlariDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Makine_Ekipman_Bakim_PlanlariDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.makine_Ekipman_Bakim_PlanlariRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.makine_Ekipman_Bakim_PlanlariRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Bakım planı veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Bakım planı bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Makine_Ekipman_Bakim_PlanlariDTO updateObject, long modifiedByUserId)
        {

                var resultObject = await _unitOfWork.makine_Ekipman_Bakim_PlanlariRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Makine_Ekipman_Bakim_PlanlariDTO,Makine_Ekipman_Bakim_Planlari>(updateObject,resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.makine_Ekipman_Bakim_PlanlariRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Bakım planı başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, "Bakım planı bulunamadı.");
            }
            
      
        }

        public async Task<IDataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>> GetAllTimeRedBirim()
        {
            var dateCriteria = DateTime.Now.Date.AddDays(-7);
            var resultObject = await _unitOfWork.makine_Ekipman_Bakim_PlanlariRepository.GetAllAsync(x => x.isActive && !x.isDeleted &&
                x.Degistirilme_Tarihi >= dateCriteria && x.OnayBirimSorumlu==2 );
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Makine_Ekipman_Bakim_PlanlariDTO>>(resultObject);
                return new DataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }



        public async Task<IDataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>> GetAllTimeRedIsgUzman()
        {
            var dateCriteria = DateTime.Now.Date.AddDays(-7);
            var resultObject = await _unitOfWork.makine_Ekipman_Bakim_PlanlariRepository.GetAllAsync(x => x.isActive && !x.isDeleted &&
                x.Degistirilme_Tarihi >= dateCriteria && x.OnayIsgUzman == 2);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Makine_Ekipman_Bakim_PlanlariDTO>>(resultObject);
                return new DataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Makine_Ekipman_Bakim_PlanlariDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

    }
}
