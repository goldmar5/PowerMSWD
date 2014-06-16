using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.TestModel.IPMPpages;
using Demo.TestModel.IPMPpages.System;
using Demo.TestModel.IPMPpages.PanelFunctionality;

namespace Demo.TestModel
{
    /**   
        The class `Pages` is an entry point for your PageObjects.   \n
        This is a Factory class, which is accessible from any place of the code.  \n
        Allows to call PegeObject actions from tests as well as from another PaeObjects   \n
    */
    public static class Pages
    {

        /**
            This method can be extended to support additional logic for all pages, 
            for instance, switch to the frame or window when it would be required or cache 
            the created pageobject instance 
        */
        public static T GetPage<T>() where T : BasePage, new()
        {
            T page = new T();
            return page;
        }

        /**
            Adding new pages
            ----------------
            For instance, you have defined a new PageObject with name `UserProfilePage` \n
            In order to have a convenient access to this page from any place of the test automation code, like this one: 

            > Pages.UserProfilePage.DoSomeAction(“param1”);

            Put the line in the following format to the list below: 

            >  public static UserProfilePage UserProfilePage { get { return GetPage<UserProfilePage>(); } }

            Please, don't be confused because the property name and returning type are same. It is allowed in C#, but, anyway, you can give any name for the property. 
        */

        // Example:
        //public static DummyExamplePage DummyExamplePage { get { return GetPage<DummyExamplePage>(); } }
        //public static EmptyPage        EmptyPage        { get { return GetPage<EmptyPage>(); } }
        //public static CreateNewAccountPage CreateNewAccountPage { get { return GetPage<CreateNewAccountPage>(); } }

        // Put your new pages here: 
        //=======================================================================================    

        public static LogoutMenuPage LogoutMenuPage { get { return GetPage<LogoutMenuPage>(); } }
        public static LogoTycoPage LogoTycoPage { get { return GetPage<LogoTycoPage>(); } }
        public static LoginPage LoginPage { get { return GetPage<LoginPage>(); } }
        public static WrongLoginPage WrongLoginPage { get { return GetPage<WrongLoginPage>(); } }
        public static PanelsPage PanelsPage { get { return GetPage<PanelsPage>(); } }
        public static GroupPage GroupPage { get { return GetPage<GroupPage>(); } }
        public static EventsPage EventsPage { get { return GetPage<EventsPage>(); } }
        public static ProcessesPage ProcessesPage { get { return GetPage<ProcessesPage>(); } }
        public static SystemPage SystemPage { get { return GetPage<SystemPage>(); } }

        //================= PANELS ====================//
        public static FaultsMonitoringPage FaultsMonitoringPage { get { return GetPage<FaultsMonitoringPage>(); } }
        public static SuspendedFaultsPage SuspendedFaultsPage { get { return GetPage<SuspendedFaultsPage>(); } }
        public static RemoteInspectionPage RemoteInspectionPage { get { return GetPage<RemoteInspectionPage>(); } }

        //================= SYSTEM ====================//
        public static UsersPage UsersPage { get { return GetPage<UsersPage>(); } }
        public static UserRolesPage UserRolesPage { get { return GetPage<UserRolesPage>(); } }
        public static UserActionLogPage UserActionLogPage { get { return GetPage<UserActionLogPage>(); } }
        public static PowerMaxPackagesPage PowerMaxPackagesPage { get { return GetPage<PowerMaxPackagesPage>(); } }
        public static PowerLinkPackagesPage PowerLinkPackagesPage { get { return GetPage<PowerLinkPackagesPage>(); } }
        public static ManageBaseConfigurationsPage ManageBaseConfigurationsPage { get { return GetPage<ManageBaseConfigurationsPage>(); } }
        public static CentralStationsPage CentralStationsPage { get { return GetPage<CentralStationsPage>(); } }
        public static RemoteInspectionValuesPage RemoteInspectionValuesPage { get { return GetPage<RemoteInspectionValuesPage>(); } }

        //================= ADD EDIT PAGES ====================//
        public static AddUnitPage AddUnitPage { get { return GetPage<AddUnitPage>(); } }
        public static EditUnitPage EditUnitPage { get { return GetPage<EditUnitPage>(); } }
        public static AddUserPage AddUserPage { get { return GetPage<AddUserPage>(); } }
        public static EditUserPage EditUserPage { get { return GetPage<EditUserPage>(); } }
        public static AddUserRolePage AddUserRolePage { get { return GetPage<AddUserRolePage>(); } }
        public static EditUserRolePage EditUserRolePage { get { return GetPage<EditUserRolePage>(); } }
        public static AddCS AddCS { get { return GetPage<AddCS>(); } }
        public static EditCS EditCS { get { return GetPage<EditCS>(); } }
        public static AddGroup AddGroup { get { return GetPage<AddGroup>(); } }
        public static EditGroup EditGroup { get { return GetPage<EditGroup>(); } }
        public static UserSettingsPage UserSettingsPage { get { return GetPage<UserSettingsPage>(); } }

        //================= PANEL FUNCTIONALITY PAGES ====================//
        public static GeneralPage GeneralPage { get { return GetPage<GeneralPage>(); } }
        public static ServicesPage ServicesPage { get { return GetPage<ServicesPage>(); } }
        public static LocationPage LocationPage { get { return GetPage<LocationPage>(); } }
        public static DiagnosticsPage DiagnosticsPage { get { return GetPage<DiagnosticsPage>(); } }
        public static RemoteInspectionsPage RemoteInspectionsPage { get { return GetPage<RemoteInspectionsPage>(); } }
        public static SetStatePage SetStatePage { get { return GetPage<SetStatePage>(); } }
        public static SetGetConfigurationPage SetGetConfigurationPage { get { return GetPage<SetGetConfigurationPage>(); } }
        public static ZonesCustomizationPage ZonesCustomizationPage { get { return GetPage<ZonesCustomizationPage>(); } }
        public static StandardLogPage StandardLogPage { get { return GetPage<StandardLogPage>(); } }
        public static LegacyLogPage LegacyLogPage { get { return GetPage<LegacyLogPage>(); } }
       
    }
}
