﻿namespace FestivalAdministration.Services.MessageDialog
{
    public interface IMessageDialogService
    {
        MessageDialogResult Show(
            string title,
            string caption,
            MessageDialogButtonConfiguration buttonConfiguration,
            MessageDialogResult defaultResult);
    }
}