﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Events;

namespace XAppFramework.Shared.Event
{
    public class PatientRegisteredArgs { }

    public class PatientRegistered : CompositePresentationEvent<PatientRegisteredArgs> { }
}
