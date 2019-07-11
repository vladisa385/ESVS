using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ESVS.Application.Catalogs.Queries;
using ESVS.Application.Catalogs.Queries.GetListCatalogs;
using ESVS.Application.Users.Queries;
using ESVS.Application.Users.Queries.GetAllUsers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ESVS.Application.Infrastructure.Query
{
    public abstract class BaseListQueryHandler<TQuery,TViewModel> :IRequestHandler<TQuery, ListResponse<TViewModel>>
        where TQuery : class,IListQuery, IRequest<ListResponse<TViewModel>>
        where TViewModel : class
    {
  
        public virtual async Task<ListResponse<TViewModel>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var query = GetQuery();
            query = ApplyFilter(query, request);
            var totalCount = await query.CountAsync(cancellationToken: cancellationToken);
            if (request.Options.Sort == null)
                request.Options.Sort = "Id";
            query = request.Options.ApplySort(query);
            query = request.Options.ApplyPaging(query);
            var items = await query.ToListAsync(cancellationToken: cancellationToken);
            return new ListResponse<TViewModel>
            {
                Items = items,
                Page = request.Options.Page,
                PageSize = request.Options.PageSize ?? -1,
                Sort = request.Options.Sort ?? "-Id",
                TotalItemsCount = totalCount
            };
        }

        protected abstract IQueryable<TViewModel> ApplyFilter(IQueryable<TViewModel> query, TQuery filter);

        protected abstract IQueryable<TViewModel> GetQuery();
    }
}
