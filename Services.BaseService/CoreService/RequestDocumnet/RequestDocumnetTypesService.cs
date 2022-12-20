using Core.Domain.Models.AppModels;
using Services.InterFaces.ICoreService.IRequestDocument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.RequestDocumnet
{
   public class RequestDocumnetTypesService : AppService<L_category_documents_types>, IRequestDocumnetTypesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RequestDocumnetTypesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }
}
