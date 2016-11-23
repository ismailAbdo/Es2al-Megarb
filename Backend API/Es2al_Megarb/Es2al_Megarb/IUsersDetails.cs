using Es2al_Megarb.DatabaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Es2al_Megarb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsersDetails" in both code and config file together.
    [ServiceContract]
    public interface IUsersDetails
    {
        [OperationContract]
        [WebInvoke (Method ="GET",ResponseFormat =WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,UriTemplate ="getAllUsers")]
        IEnumerable<User> getAllUsers();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getUser/{userID}")]
        IEnumerable<User> getUser(string userID);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, UriTemplate = "addUser")]
        int addUser(User u);

        [OperationContract]
        [WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, UriTemplate = "updateUser/{userID}")]
        int updateUser(string userID , User u);
    }
}
