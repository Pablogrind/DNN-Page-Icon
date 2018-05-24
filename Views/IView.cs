/*
' Copyright (c) 2014 Panter
' http://www.panter.co
' All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/
using System.Collections.Generic;
using DotNetNuke.Web.Mvp;

namespace Panter.Modules.PageIcon.Views
{
    /// <summary>
    /// IItemListView - interface for the item detail view
    /// </summary>
    public interface IItemView : IModuleView<Models.Item>
    {
        /// <summary>
        /// </summary>
        List<Models.Item> RecordList { get; set; }

        event System.EventHandler<ViewLoadEventArgs> LoadData;
    }

    public class ViewLoadEventArgs : System.EventArgs
    {
        public int ModuleId { get; set; }
    }
}