﻿using static WorkingTimerApp.TimerBase;

namespace WorkingTimerApp
{
    public interface ITimer
    {
        string Category { get; }

        string FileName { get; }

        void AddTime(string time);

        Statistics GetStatistics();

        void ShowPartialStatistics();

        void ShowSummaryStatistics();

        event TimeAddedDelegate TimeAdded;
    }
}
