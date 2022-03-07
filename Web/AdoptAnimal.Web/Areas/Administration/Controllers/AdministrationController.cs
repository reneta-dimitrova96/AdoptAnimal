﻿namespace AdoptAnimal.Web.Areas.Administration.Controllers
{
    using AdoptAnimal.Common;
    using AdoptAnimal.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
