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
using System;
using System.Web.Caching;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace Panter.Modules.PageIcon.Models
{
    [Serializable]
    [TableName("Item")]
    //setup the primary key for table
    [PrimaryKey("ItemID", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("Item", CacheItemPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    public class Item
    {
        public int ItemID { get; set; }
        public int ModuleId { get; set; }
        public string IconURL { get; set; }
    }
}