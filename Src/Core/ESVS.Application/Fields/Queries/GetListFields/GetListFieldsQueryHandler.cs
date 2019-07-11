using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper.QueryableExtensions;
using ESVS.Application.Infrastructure.Query;
using ESVS.Application.Interfaces;

namespace ESVS.Application.Fields.Queries.GetListFields
{
    public class GetListFieldsQueryHandler:BaseListQueryHandler<GetListFieldsQuery,FieldViewModel>
    {
        private readonly IESVSDbContext _context;

        public GetListFieldsQueryHandler(IESVSDbContext context) => 
            _context = context;

        protected override IQueryable<FieldViewModel> ApplyFilter(IQueryable<FieldViewModel> query, GetListFieldsQuery filter)
        {
            if (filter.Id != null)
                query = query.Where(p => p.Id == filter.Id);

            if (filter.Name != null)
                query = query.Where(p => p.Name.Contains(filter.Name));

            if (filter.Caption != null)
                query = query.Where(p => p.Caption.Contains(filter.Caption));

            if (filter.TypeId != null)
                query = query.Where(p => p.TypeId == filter.TypeId);

            if (filter.CatalogId != null)
                query = query.Where(p => p.CatalogId == filter.CatalogId);

            if (filter.IsForeignKey != null)
                query = query.Where(p => p.IsForeignKey == filter.IsForeignKey);

            if (filter.NotNull != null)
                query = query.Where(p => p.NotNull == filter.NotNull);
            if (filter.Length != null)
            {
                if (filter.Length.From != null)
                    query = query.Where(p => p.Length >= filter.Length.From);

                if (filter.Length.To != null)
                    query = query.Where(p => p.Length <= filter.Length.To);
            }
            if (filter.FieldValues != null)
            {
                if (filter.FieldValues.From != null)
                    query = query.Where(p => p.FieldValuesCount >= filter.FieldValues.From);

                if (filter.FieldValues.To != null)
                    query = query.Where(p => p.FieldValuesCount <= filter.FieldValues.To);
            }
            return query;
        }

        protected override IQueryable<FieldViewModel> GetQuery() => 
            _context.Catalogs.ProjectTo<FieldViewModel>();
    }
}
