﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2032
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace DBAccessor {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class DSUserantwortselect : DataSet {
        
        private userantwortselectDataTable tableuserantwortselect;
        
        public DSUserantwortselect() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected DSUserantwortselect(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["userantwortselect"] != null)) {
                    this.Tables.Add(new userantwortselectDataTable(ds.Tables["userantwortselect"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.InitClass();
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public userantwortselectDataTable userantwortselect {
            get {
                return this.tableuserantwortselect;
            }
        }
        
        public override DataSet Clone() {
            DSUserantwortselect cln = ((DSUserantwortselect)(base.Clone()));
            cln.InitVars();
            return cln;
        }
        
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        protected override void ReadXmlSerializable(XmlReader reader) {
            this.Reset();
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            if ((ds.Tables["userantwortselect"] != null)) {
                this.Tables.Add(new userantwortselectDataTable(ds.Tables["userantwortselect"]));
            }
            this.DataSetName = ds.DataSetName;
            this.Prefix = ds.Prefix;
            this.Namespace = ds.Namespace;
            this.Locale = ds.Locale;
            this.CaseSensitive = ds.CaseSensitive;
            this.EnforceConstraints = ds.EnforceConstraints;
            this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
            this.InitVars();
        }
        
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new XmlTextReader(stream), null);
        }
        
        internal void InitVars() {
            this.tableuserantwortselect = ((userantwortselectDataTable)(this.Tables["userantwortselect"]));
            if ((this.tableuserantwortselect != null)) {
                this.tableuserantwortselect.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "DSUserantwortselect";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/DSUserantwortselect.xsd";
            this.Locale = new System.Globalization.CultureInfo("de-DE");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableuserantwortselect = new userantwortselectDataTable();
            this.Tables.Add(this.tableuserantwortselect);
        }
        
        private bool ShouldSerializeuserantwortselect() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void userantwortselectRowChangeEventHandler(object sender, userantwortselectRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class userantwortselectDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnUawsID;
            
            private DataColumn columnr_AntwortID;
            
            internal userantwortselectDataTable() : 
                    base("userantwortselect") {
                this.InitClass();
            }
            
            internal userantwortselectDataTable(DataTable table) : 
                    base(table.TableName) {
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            internal DataColumn UawsIDColumn {
                get {
                    return this.columnUawsID;
                }
            }
            
            internal DataColumn r_AntwortIDColumn {
                get {
                    return this.columnr_AntwortID;
                }
            }
            
            public userantwortselectRow this[int index] {
                get {
                    return ((userantwortselectRow)(this.Rows[index]));
                }
            }
            
            public event userantwortselectRowChangeEventHandler userantwortselectRowChanged;
            
            public event userantwortselectRowChangeEventHandler userantwortselectRowChanging;
            
            public event userantwortselectRowChangeEventHandler userantwortselectRowDeleted;
            
            public event userantwortselectRowChangeEventHandler userantwortselectRowDeleting;
            
            public void AdduserantwortselectRow(userantwortselectRow row) {
                this.Rows.Add(row);
            }
            
            public userantwortselectRow AdduserantwortselectRow(int r_AntwortID) {
                userantwortselectRow rowuserantwortselectRow = ((userantwortselectRow)(this.NewRow()));
                rowuserantwortselectRow.ItemArray = new object[] {
                        null,
                        r_AntwortID};
                this.Rows.Add(rowuserantwortselectRow);
                return rowuserantwortselectRow;
            }
            
            public userantwortselectRow FindByUawsID(int UawsID) {
                return ((userantwortselectRow)(this.Rows.Find(new object[] {
                            UawsID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                userantwortselectDataTable cln = ((userantwortselectDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new userantwortselectDataTable();
            }
            
            internal void InitVars() {
                this.columnUawsID = this.Columns["UawsID"];
                this.columnr_AntwortID = this.Columns["r_AntwortID"];
            }
            
            private void InitClass() {
                this.columnUawsID = new DataColumn("UawsID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnUawsID);
                this.columnr_AntwortID = new DataColumn("r_AntwortID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnr_AntwortID);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnUawsID}, true));
                this.columnUawsID.AutoIncrement = true;
                this.columnUawsID.AllowDBNull = false;
                this.columnUawsID.ReadOnly = true;
                this.columnUawsID.Unique = true;
                this.columnr_AntwortID.AllowDBNull = false;
            }
            
            public userantwortselectRow NewuserantwortselectRow() {
                return ((userantwortselectRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new userantwortselectRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(userantwortselectRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.userantwortselectRowChanged != null)) {
                    this.userantwortselectRowChanged(this, new userantwortselectRowChangeEvent(((userantwortselectRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.userantwortselectRowChanging != null)) {
                    this.userantwortselectRowChanging(this, new userantwortselectRowChangeEvent(((userantwortselectRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.userantwortselectRowDeleted != null)) {
                    this.userantwortselectRowDeleted(this, new userantwortselectRowChangeEvent(((userantwortselectRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.userantwortselectRowDeleting != null)) {
                    this.userantwortselectRowDeleting(this, new userantwortselectRowChangeEvent(((userantwortselectRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveuserantwortselectRow(userantwortselectRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class userantwortselectRow : DataRow {
            
            private userantwortselectDataTable tableuserantwortselect;
            
            internal userantwortselectRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableuserantwortselect = ((userantwortselectDataTable)(this.Table));
            }
            
            public int UawsID {
                get {
                    return ((int)(this[this.tableuserantwortselect.UawsIDColumn]));
                }
                set {
                    this[this.tableuserantwortselect.UawsIDColumn] = value;
                }
            }
            
            public int r_AntwortID {
                get {
                    return ((int)(this[this.tableuserantwortselect.r_AntwortIDColumn]));
                }
                set {
                    this[this.tableuserantwortselect.r_AntwortIDColumn] = value;
                }
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class userantwortselectRowChangeEvent : EventArgs {
            
            private userantwortselectRow eventRow;
            
            private DataRowAction eventAction;
            
            public userantwortselectRowChangeEvent(userantwortselectRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public userantwortselectRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}
