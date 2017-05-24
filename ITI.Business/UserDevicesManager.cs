using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Data.DataRepositoy;
using ITI.Data.DBmodel;

namespace ITI.Business.Manager
{
    public class UserDevicesManager : DataRepositoy<ITIEntities, UserDevice>
    {
        public bool AddUserDevice(UserDevice UserDevices)
        {
            if (!new UserDevicesManager().FindBy(x => x.DevicesID == UserDevices.DevicesID).Any())
            {
                new UserDevicesManager().Add(UserDevices);
                return true;
            }


            return false;
        }

        public IEnumerable<UserDevice> GetUserDevice(int EmployeeID)
        {

            return new UserDevicesManager().FindBy(x => x.EmployeeID == EmployeeID);
        }
        public IEnumerable<UserDevice> GetStudentUserDevice(int StudentID)
        {

            return new UserDevicesManager().FindBy(x => x.StudentID == StudentID);
        }
    }
}
