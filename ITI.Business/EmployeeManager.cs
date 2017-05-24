
using ITI.Data;
using ITI.Data.DataRepositoy;
using ITI.Data.DBmodel;
using System.Collections.Generic;
using System.Linq;


namespace ITI.Business.Manager
{
    public class EmployeeManager : DataRepositoy<ITIEntities, Employee>
    {
        public IEnumerable<Employee> getemp()
        {
         // System.Data. DbContext.Configuration.ProxyCreationEnabled = false;
            return new EmployeeManager().GetAll();
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