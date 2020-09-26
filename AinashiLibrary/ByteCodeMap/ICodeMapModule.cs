﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using AinashiLibraryCSharp.Extensions;

namespace AinashiLibraryCSharp.ByteCodeMap
{

    /// <summary>
    /// バイトコードマップの各ノードを包括的に管理するクラス用のインターフェース。
    /// </summary>
    interface ICodeMapModule<NodeType> : ICodeMapModule
        where NodeType: INodeViewer
    {


        /* *'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'* *\
         * 
         * Inherit from ICodeMapModule(non-generics)
         * 
        \* *,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,* */

        #region Inherit from ICodeMapModule(non-generics)

        ReadOnlyCollection<INodeViewer> ICodeMapModule.RootNodes
        {
            get
            {

                var src = RootNodes;
                var ans = new INodeViewer[src.Count];

                src.CopyTo(ans, src.Count);

                return Array.AsReadOnly(ans);

            }
        }

        #endregion

        /* *'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'* *\
         * 
         * Infomation Property
         * 
        \* *,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,* */

        #region Infomation Property

        /// <summary>
        /// このモジュールが管理している最上位ノードの一覧を取得します。
        /// </summary>
        new ReadOnlyCollection<NodeType> RootNodes { get; }



        #endregion

    }

    /// <summary>
    /// <see cref="ICodeMapModule{NodeType}"/>の共通実装。
    /// </summary>
    interface ICodeMapModule
    {


        /* *'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'*'* *\
         * 
         * Infomation Property
         * 
        \* *,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,*,* */

        #region Infomation Property

        /// <summary>
        /// 読み取り専用かどうかを取得します。
        /// </summary>
        bool isReadOnly { get; }

        /// <summary>
        /// このモジュールが管理している最上位ノードの一覧を取得します。
        /// </summary>
        ReadOnlyCollection<INodeViewer> RootNodes { get; }

        #endregion


    }

}