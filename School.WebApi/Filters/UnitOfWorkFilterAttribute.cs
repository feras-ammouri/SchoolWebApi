using Microsoft.AspNetCore.Mvc.Filters;
using School.DataAccess.Transactions;
using School.DataAccess.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApi.Filters
{
    public class UnitOfWorkFilterAttribute : ActionFilterAttribute
    {
        private readonly IUnitOfWork _unitOfWork;

        private ITransaction _transaction;

        public UnitOfWorkFilterAttribute(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _transaction = _unitOfWork.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception == null)
            {
                _unitOfWork.Save();
                _transaction.Commit();

                _transaction.Dispose();
                _unitOfWork.Dispose();
            }
            else
            {
                try
                {
                    _transaction.Rollback();
                }
                catch(Exception exception)
                {
                    throw new AggregateException(actionExecutedContext.Exception, exception);
                }
            }
        }
    }
}
