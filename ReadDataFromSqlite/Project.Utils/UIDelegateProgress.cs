using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Utils
{
    /// <summary>
    /// 委托进度
    /// </summary>
    public class UIDelegateProgress
    {
        public event Action ProgressCompleted;

        /// <summary>
        /// UI委托处理
        /// </summary>
        /// <param name="uiTask"></param>
        public async void StartAsync(Func<Task> uiTask)
        {
            try
            {
                await uiTask.Invoke();
            }
            catch (InvalidOperationException e)
            {
                
            }
            finally
            {
                ProgressCompleted?.Invoke();
            }
        }

        /// <summary>
        /// UI委托处理
        /// </summary>
        /// <param name="uiTask"></param>
        public void Start(Action uiTask)
        {
            try
            {
                uiTask.Invoke();
            }
            catch (InvalidOperationException e)
            {
            }
            finally
            {
                ProgressCompleted?.Invoke();
            }
        }
    }

    /// <summary>
    /// 委托进度
    /// </summary>
    public class UIDelegateProgress<T>
    {
        public event Action ProgressCompleted;

        /// <summary>
        /// 输入参数
        /// </summary>
        public T Parameter { get; set; }

        /// <summary>
        /// 输出参数
        /// </summary>
        public T Result { get; set; }

        public UIDelegateProgress()
        {

        }
        public UIDelegateProgress(T parameter)
        {
            Parameter = parameter;
        }

        /// <summary>
        /// UI委托处理
        /// </summary>
        /// <param name="uiTask"></param>
        public void Start(Action<T> uiTask)
        {
            try
            {
                uiTask.Invoke(Parameter);
            }
            catch (InvalidOperationException e)
            {
            }
            finally
            {
                ProgressCompleted?.Invoke();
            }
        }

        /// <summary>
        /// UI委托处理
        /// </summary>
        /// <param name="uiTask"></param>
        public async void StartAsync(Func<T, Task> uiTask)
        {
            try
            {
                await uiTask.Invoke(Parameter);
            }
            catch (InvalidOperationException e)
            {
            }
            finally
            {
                ProgressCompleted?.Invoke();
            }
        }

        /// <summary>
        /// UI委托处理
        /// </summary>
        /// <param name="uiTask"></param>
        public void Start(Func<T> uiTask)
        {
            try
            {
                Result = uiTask.Invoke();
            }
            catch (InvalidOperationException e)
            {
            }
            finally
            {
                ProgressCompleted?.Invoke();
            }
        }

        /// <summary>
        /// UI委托处理
        /// </summary>
        /// <param name="uiTask"></param>
        public async void StartAsync(Func<Task<T>> uiTask)
        {
            try
            {
                Result = await uiTask.Invoke();
            }
            catch (InvalidOperationException e)
            {
            }
            finally
            {
                ProgressCompleted?.Invoke();
            }
        }
    }

    /// <summary>
    /// 委托进度
    /// </summary>
    public class UIDelegateProgress<TInput, TOut>
    {
        public event Action ProgressCompleted;

        /// <summary>
        /// 输入参数
        /// </summary>
        public TInput Parameter { get; set; }

        /// <summary>
        /// 输出参数
        /// </summary>
        public TOut Result { get; set; }

        public UIDelegateProgress(TInput parameter)
        {
            Parameter = parameter;
        }

        /// <summary>
        /// UI委托处理
        /// </summary>
        /// <param name="uiTask"></param>
        public async void StartAsync(Func<TInput, Task<TOut>> uiTask)
        {
            try
            {
                Result = await uiTask.Invoke(Parameter);
            }
            catch (InvalidOperationException e)
            {
            }
            finally
            {
                ProgressCompleted?.Invoke();
            }
        }

        /// <summary>
        /// UI委托处理
        /// </summary>
        /// <param name="uiTask"></param>
        public void Start(Func<TOut> uiTask)
        {
            try
            {
                uiTask.Invoke();
            }
            catch (InvalidOperationException e)
            {
            }
            finally
            {
                ProgressCompleted?.Invoke();
            }
        }

        /// <summary>
        /// UI委托处理
        /// </summary>
        /// <param name="uiTask"></param>
        public void Start(Func<TInput, TOut> uiTask)
        {
            try
            {
                Result = uiTask.Invoke(Parameter);
            }
            catch (InvalidOperationException e)
            {
            }
            finally
            {
                ProgressCompleted?.Invoke();
            }
        }
    }
}
