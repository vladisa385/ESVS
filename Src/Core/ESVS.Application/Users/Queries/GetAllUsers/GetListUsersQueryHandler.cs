﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ESVS.Application.Infrastructure.Query;
using ESVS.Application.Interfaces;
using MediatR;

namespace ESVS.Application.Users.Queries.GetAllUsers
{
    public class GetListUsersQueryHandler:BaseListQueryHandler<GetListUsersQuery,UserViewModel>
    {
        private readonly IESVSDbContext _context;
        private readonly IMapper _mapper;

        public GetListUsersQueryHandler(IESVSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override IQueryable<UserViewModel> ApplyFilter(IQueryable<UserViewModel> query, GetListUsersQuery filter)
        {
            if (filter.Id != null)
                query = query.Where(p => p.Id == filter.Id);

            if (filter.FirstName != null)
                query = query.Where(p => p.FirstName.Contains(filter.FirstName));

            if (filter.LastName != null)
                query = query.Where(p => p.LastName.Contains(filter.LastName));

            if (filter.Email != null)
                query = query.Where(p => p.Email.Contains(filter.Email));

            if (filter.Gender != null)
                query = query.Where(p => p.Gender == filter.Gender);
            return query;
        }

        protected override IQueryable<UserViewModel> GetQuery() =>
            _context.Users.ProjectTo<UserViewModel>(_mapper.ConfigurationProvider);
    }
}
