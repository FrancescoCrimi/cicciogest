// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System.Threading;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModels
{
    /// <summary>
    /// Defines asynchronous navigation lifecycle events for ViewModels.
    /// Implement this interface when a ViewModel needs to react to navigation
    /// events such as entering or leaving a page, or when it must decide whether
    /// navigation is allowed to proceed.
    /// </summary>
    public interface INavigationAwareAsync
    {
        /// <summary>
        /// Called after the ViewModel has been navigated to and the associated view
        /// has been displayed. Use this method to perform asynchronous initialization,
        /// such as loading data or starting background operations.
        /// 
        /// This method receives a CancellationToken that will be triggered if the
        /// navigation is cancelled or replaced by another navigation request.
        /// </summary>
        /// <param name="parameter">Optional navigation parameter.</param>
        /// <param name="cancellationToken">Token used to cancel the initialization work.</param>
        Task OnNavigatedToAsync(object? parameter, CancellationToken cancellationToken = default);

        /// <summary>
        /// Called when the ViewModel is being removed from the navigation stack.
        /// Use this method to perform cleanup, stop timers, unsubscribe from events,
        /// or release unmanaged resources.
        /// 
        /// This method also receives a CancellationToken, although it is typically
        /// not required unless cleanup operations are long-running.
        /// </summary>
        /// <param name="cancellationToken">Token used to cancel cleanup work.</param>
        Task OnNavigatedFromAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Called before navigating away from the ViewModel.
        /// Return true to allow navigation to proceed, or false to cancel it.
        /// 
        /// This method is useful for scenarios such as:
        /// - unsaved changes
        /// - confirmation dialogs
        /// - validation before leaving the page
        /// 
        /// The CancellationToken allows you to cancel any asynchronous checks
        /// if navigation is aborted or replaced.
        /// </summary>
        /// <param name="cancellationToken">Token used to cancel the navigation check.</param>
        /// <returns>True to allow navigation, false to block it.</returns>
        Task<bool> OnNavigatingFromAsync(CancellationToken cancellationToken = default);
    }
}
