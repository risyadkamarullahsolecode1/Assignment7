﻿using Assignment7.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Application.Interfaces
{
    public interface IBookRequestService
    {
        Task<BaseResponseDto> SubmitJobPostRequest(BookRequestDto request);
        Task<BaseResponseDto> ReviewJobPostRequest(ReviewRequestDto reviewRequest);
        Task<IEnumerable<object>> GetAllBookRequestStatuses();
        Task<ProcessDetailDto> GetProcessAsync(int processId);
    }
}
