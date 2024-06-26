﻿using AutoMapper;
using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Interfaces.Services.Factories;
using BusinessLogic.Interfaces.Services.UserService;
using BusinessLogic.Interfaces.Services.Utilites;
using Microsoft.Extensions.Configuration;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.UserService
{
    public class UserService: IUserService
    {

        private readonly IMapper _mapper;
        private readonly IGenericRepository<User1> _gen;
        private readonly IUserFactory _userFactory;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public UserService(IMapper mapper,IGenericRepository<User1> gen,IUserFactory userFactory, IUserRepository userRepository, IConfiguration config)
        { 
            _gen = gen;
            _userRepository = userRepository;
            _config = config;
            _mapper = mapper;
            _userFactory = userFactory;
        }

        public async Task<User1> Post(UserDto dto)
        {
            long id = await Get(dto.Email);
            if (id>0)
            {
               
                return await _gen.Get(id);
            }
            User1 user = _mapper.Map<User1>(dto);
            user=_userFactory.CreateUser(user);
            return await _gen.Post(user);
        }

        public async Task<long> Get(string mail)
        {
            return await _userRepository.GetUserID(mail);
        }
        public async Task<object> Post(LoginDto loginDto)
        {

            return null;
        }
    }
}
