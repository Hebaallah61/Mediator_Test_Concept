﻿using MediatorDemoLibrary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDemoLibrary.Commands
{
    public record DeleteUserCommand(int id):IRequest<List<UserModel>>;
}
