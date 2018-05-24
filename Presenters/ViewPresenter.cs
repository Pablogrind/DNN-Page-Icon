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
using DotNetNuke.Web.Mvp;

namespace Panter.Modules.PageIcon.Presenters
{
    /// <summary>
    /// ItemListPresenter - presenter object for a list of items
    /// </summary>
    public class ViewPresenter : ModulePresenter<Views.IItemView, Models.Item>
    {
        /// <summary>
        /// </summary>
        public ViewPresenter(Views.IItemView view)
            : base(view)
        {
            if (base.ModuleContext != null)
            {
            }

           this.View.LoadData += LoadData;
        }

        public void LoadData(object sender, Views.ViewLoadEventArgs args)
        {
        }
    }
}