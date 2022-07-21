using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

using System.Security.Permissions;

namespace WindowsFormsApp1
{
    public class RegCurrentUser
    {

        public static void update(string regPath, string name, string value)
        {
            try
            {
                //Registry.LocalMachine
                RegistryKey Part = Registry.CurrentUser.OpenSubKey(regPath, true);
                if (Part == null)
                {
                    Create(regPath);
                    Part = Registry.CurrentUser.OpenSubKey(regPath, true);
                }
                if (Part == null)
                {
                    return;
                }

                Part.SetValue(name, value);
                Part.Close();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
                return;
            }

        }

        /// <summary>
        /// 创建项与键值
        /// </summary>
        private static void Create(string regPath)
        {

            try
            {
                RegistryKey key = Registry.CurrentUser;
                RegistryKey old = key;
                string[] paths = regPath.Split('\\');
                foreach (string path in paths)
                {
                    key = old.OpenSubKey(path, true);
                    if (key == null)
                    {
                        key = old.CreateSubKey(path);
                    }
                    old.Close();
                    old = key;
                }

            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
            }
        }
        
        /// <summary>
        /// 判断键值是否存在
        /// </summary>
        /// <param name="RegBoot"></param>
        /// <param name="RegKeyName"></param>
        /// <returns></returns>
        private static bool IsRegeditKeyExist(RegistryKey RegBoot, string RegKeyName)
        {

            string[] subkeyNames;
            subkeyNames = RegBoot.GetValueNames();
            foreach (string keyName in subkeyNames)
            {

                if (keyName == RegKeyName)  //判断键值的名称
                {
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// 判断项是否存在
        /// </summary>
        /// <param name="RegBoot"></param>
        /// <param name="ItemName"></param>
        /// <returns></returns>
        private static bool IsRegeditItemExist(RegistryKey RegBoot, string ItemName)
        {
            if (ItemName.IndexOf("\\") <= -1)
            {
                string[] subkeyNames;
                subkeyNames = RegBoot.GetValueNames();
                foreach (string ikeyName in subkeyNames)  //遍历整个数组
                {
                    if (ikeyName == ItemName) //判断子项的名称
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                string[] strkeyNames = ItemName.Split('\\');
                RegistryKey _newsubRegKey = RegBoot.OpenSubKey(strkeyNames[0]);
                string _newRegKeyName = "";
                int i;
                for (i = 1; i < strkeyNames.Length; i++)
                {
                    _newRegKeyName = _newRegKeyName + strkeyNames[i];
                    if (i != strkeyNames.Length - 1)
                    {
                        _newRegKeyName = _newRegKeyName + "\\";
                    }
                }
                return IsRegeditItemExist(_newsubRegKey, _newRegKeyName);
            }
        }

    }

    /// <summary>
    /// 只能读取
    /// </summary>
    public class RegLocalMachine
    {
        
        public static void update(string regPath, string name, string value)
        {
            try
            {
                //Registry.LocalMachine
                RegistryKey Part = Registry.LocalMachine.OpenSubKey(regPath, true);
                if (Part == null)
                {
                    Create(regPath);
                    Part = Registry.LocalMachine.OpenSubKey(regPath, true);
                }
                if (Part == null)
                {
                    return;
                }

                Part.SetValue(name, value);
                Part.Close();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
                return;
            }

        }

        /// <summary>
        /// 创建项与键值
        /// </summary>
        private static void Create(string regPath)
        {
            
            try
            {
                RegistryKey key = Registry.LocalMachine;
                RegistryKey old = key;
                string[] paths = regPath.Split('\\');
                foreach (string path in paths)
                {
                    
                    key = old.OpenSubKey(path, true);
                    if (key == null)
                    {
                        key = old.CreateSubKey(path);
                    }
                    old.Close();
                    old = key;
                }

            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
            }
        }
        /// <summary>
        /// 判断键值是否存在
        /// </summary>
        /// <param name="RegBoot"></param>
        /// <param name="RegKeyName"></param>
        /// <returns></returns>
        private static bool IsRegeditKeyExist(RegistryKey RegBoot, string RegKeyName)
        {

            string[] subkeyNames;
            subkeyNames = RegBoot.GetValueNames();
            foreach (string keyName in subkeyNames)
            {

                if (keyName == RegKeyName)  //判断键值的名称
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 判断项是否存在
        /// </summary>
        /// <param name="RegBoot"></param>
        /// <param name="ItemName"></param>
        /// <returns></returns>
        private static bool IsRegeditItemExist(RegistryKey RegBoot, string ItemName)
        {
            if (ItemName.IndexOf("\\") <= -1)
            {
                string[] subkeyNames;
                subkeyNames = RegBoot.GetValueNames();
                foreach (string ikeyName in subkeyNames)  //遍历整个数组
                {
                    if (ikeyName == ItemName) //判断子项的名称
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                string[] strkeyNames = ItemName.Split('\\');
                RegistryKey _newsubRegKey = RegBoot.OpenSubKey(strkeyNames[0]);
                string _newRegKeyName = "";
                int i;
                for (i = 1; i < strkeyNames.Length; i++)
                {
                    _newRegKeyName = _newRegKeyName + strkeyNames[i];
                    if (i != strkeyNames.Length - 1)
                    {
                        _newRegKeyName = _newRegKeyName + "\\";
                    }
                }
                return IsRegeditItemExist(_newsubRegKey, _newRegKeyName);
            }
        }
    }
}
