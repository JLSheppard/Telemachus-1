﻿//Author: Richard Bunt
using System;
using System.Collections.Generic;
using System.Text;
using Telemachus;

namespace Telemachus
{
    public class VesselChangeDetector
    {
        public event EventHandler<EventArgs> UpdateNotify;

        public static bool hasTelemachusPart = false;

        private EventArgs updateEventArgs;

        public void update(Vessel vessel)
        {
            if (UpdateNotify != null)
            {
                UpdateNotify(this,updateEventArgs);
            }

            if (vessel != null)
            {
                updateHasTelemachusPart(vessel);
            }
        }

        private void updateHasTelemachusPart(Vessel vessel)
        {
            try
            {
                hasTelemachusPart = vessel.parts.FindAll(p => p.Modules.Contains("TelemachusDataLink")).Count > 0;
            }
            catch (Exception e)
            {
                PluginLogger.debug(e.Message + " " + e.StackTrace);
            }
        }
    }
}
