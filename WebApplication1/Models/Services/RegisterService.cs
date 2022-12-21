using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.EFModels;
using WebApplication1.Models.Repositories;

namespace WebApplication1.Models.Services
{
    public class RegisterService
    {
        private RegisterRepository repository = new RegisterRepository();
        public void Create(Register register)
        {
            // 驗證Email 是否已經存在
            var dataInDb = repository.FindbyEmail(register.Email);
         
            if (dataInDb != null)  // 表示資料表有這筆資料
            {
                throw new Exception("這個Email已經報名過了,無法再度報名");
            }
            // 用程式指定建檔時間,而不是由使用者輸入
            register.CreatedTime = DateTime.Now;

            repository.Create(register);

        }

        public Register Find(int id)
        {
            Register register = repository.FindbyId(id);

            if (register == null)
            {
                throw new Exception("找不到指定的紀錄");
            }

            return register;
        }
       
    }
}