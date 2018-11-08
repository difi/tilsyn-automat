using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;

namespace Log
{
    public class DeclarationRepositoryLogDecorator: IDeclarationRepository
    {
        private readonly IDeclarationRepository inner;
        private readonly ILogRepository logRepository;

        public DeclarationRepositoryLogDecorator(IDeclarationRepository inner, ILogRepository logRepository)
        {
            this.inner = inner;
            this.logRepository = logRepository;
        }

        public ApiResult<T> Get<T>(Guid id) where T : DeclarationItem
        {
            throw new NotImplementedException();
        }

        public ApiResult<T> GetAll<T>() where T : List<DeclarationItem>
        {
            throw new NotImplementedException();
        }

        public ApiResult Add(DeclarationItem declarationItem)
        {
            throw new NotImplementedException();
        }

        public ApiResult Update(DeclarationItem declarationItem)
        {
            throw new NotImplementedException();
        }

        public ApiResult SendIn(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}