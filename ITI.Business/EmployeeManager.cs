using System;
using ITI.Data;
using ITI.Data.DataRepositoy;
using ITI.Data.DBmodel;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ITI.Business.Map;

namespace ITI.Business.Manager
{
    public class EmployeeManager : DataRepositoy<ITIEntities, Employee>
    {
        public IEnumerable<EmployeeMap> Getemp()
        {
            var x = GetAll().ToList();
            return Mapper.Map<IEnumerable<EmployeeMap>>(x);
            // System.Data. DbContext.Configuration.ProxyCreationEnabled = false;
           // return new EmployeeManager().GetAll();
        }
        public EmployeeMap Getemp(int id)
        {
            var x = Get(id);
           var e= Mapper.Map<EmployeeMap>(x);
            return e;

        }
        public EmployeeMap Getemp(string username,string pwd)
        {
            var x = FindobjBy(a => a.UserName2 == username);
            var re = Mapper.Map<EmployeeMap>(x);
            if (re.IPassword == pwd)
            {
                return re;
            }
            else
            {
                return null;
            }


        }

        //    public Group AddGroup(Group group)
        //    {
        //        GroupManager groupmanager = new GroupManager();
        //        return groupmanager.Add(group);
        //        // groupmanager.Save();
        //       // return group.GroupID.ToString();
        //    }
        //    public bool EditGroup(Group group)
        //    {
        //        return new GroupManager().Edit(group);
        //    }
        //    public bool DeleteGroup(int groupid)
        //    {
        //        GroupManager groupManager = new GroupManager();
        //        Group groups = groupManager.FindBy(x => x.GroupID == groupid).FirstOrDefault();
        //        return groupManager.Delete(groups);
        //    }
        //    public IEnumerable<Group> GetSystemGroup()
        //    {
        //       // return FindBy(x => x.GroupSystem == false && x.GroupCreatorID == groupCreatorId);
        //        return new GroupManager().FindBy(x => x.GroupSystem == true);
        //    }
        //    public IEnumerable<Group> GetUserGroup(int groupCreatorId, ODataQueryOptions<Group> options, ApiController controller)
        //    {
        //       //string xx= FindBy(x => x.GroupSystem == false && x.GroupCreatorID == groupCreatorId).ToString();
        //        return FindBy(x => x.GroupSystem == false && x.GroupCreatorID == groupCreatorId,options,controller);
        //    }
    }
}