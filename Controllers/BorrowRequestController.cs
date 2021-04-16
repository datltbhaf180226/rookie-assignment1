using Library.Models;
using Library.Repositoties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Controllers
{
    [Route("borrowRequests")]
    [ApiController]
    public class BorrowRequestController : ControllerBase
    {
        private readonly IRepository<BorrowRequest> _brRepository;

        public BorrowRequestController(IRepository<BorrowRequest> brRepository)
        {
            _brRepository = brRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var borrowRequests = _brRepository.GetAll(b => b.BorrowRequestDetails, b => b.User).ToList();
            
            if (borrowRequests != null)
            {
                return Ok(borrowRequests);
            }

            return BadRequest("Co loi xay ra!");
        }

        [Authorize(Roles = "User, Admin")]
        [HttpGet("{userId}")]
        public IActionResult GetAllRequestsByUserId(int userId)
        {
            var borrowRequests = _brRepository.GetAll(b => b.BorrowRequestDetails, b => b.User).Where(b => b.UserId == userId).ToList();

            if (borrowRequests != null)
            {
                foreach(var borrowRequest in borrowRequests)
                {
                    borrowRequest.User.BorrowRequests = null;
                }    
                return Ok(borrowRequests);
            }

            return BadRequest("Co loi xay ra!");
        }

        [Authorize(Roles = "User, Admin")]
        [HttpPost("{userId}")]
        public IActionResult Insert(BorrowRequest borrowRequest, int userId)
        {
            var checkBorrowInMonth = _brRepository.GetAll().Count(br => br.UserId == userId && br.BorrowDate.Month == DateTime.Now.Month);

            if (checkBorrowInMonth < 3)
            {
                if (borrowRequest.BorrowRequestDetails.Count <= 5)
                {
                    borrowRequest.BorrowDate = DateTime.Now;
                    borrowRequest.Status = (Status)0;
                    borrowRequest.UserId = userId;
                    _brRepository.Insert(borrowRequest);
                    return Ok(borrowRequest);
                }
                return BadRequest("Ban ko the muon 5 cuon sach 1 luc");
            }
            return BadRequest("Ban ko the muon qua 3 lan trong 1 thang");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{borrowRequestId}/approve")]
        public IActionResult ApproveBorrowRequest(int borrowRequestId)
        {
            if (!ModelState.IsValid) return BadRequest("Co loi xay ra!");

            var entity = _brRepository.Get(borrowRequestId);

            if (entity != null)
            {
                entity.Status = (Status)1;
                _brRepository.Update(entity);
                return Ok(entity);
            }

            return BadRequest("Khong tim thay book co id la " + borrowRequestId!);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{borrowRequestId}/reject")]
        public IActionResult RejectBorrowRequest(int borrowRequestId)
        {
            if (!ModelState.IsValid) return BadRequest("Co loi xay ra!");

            var entity = _brRepository.Get(borrowRequestId);

            if (entity != null)
            {
                entity.Status = (Status)2;
                _brRepository.Update(entity);
                return Ok(entity);
            }

            return BadRequest("Khong tim thay book co id la " + borrowRequestId!);
        }
    }
}