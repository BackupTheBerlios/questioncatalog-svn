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
    public class DSAwmoeglichkeiten : DataSet {
        
        private awmoeglichkeitenDataTable tableawmoeglichkeiten;
        
        public DSAwmoeglichkeiten() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected DSAwmoeglichkeiten(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["awmoeglichkeiten"] != null)) {
                    this.Tables.Add(new awmoeglichkeitenDataTable(ds.Tables["awmoeglichkeiten"]));
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
        public awmoeglichkeitenDataTable awmoeglichkeiten {
            get {
                return this.tableawmoeglichkeiten;
            }
        }
        
        public override DataSet Clone() {
            DSAwmoeglichkeiten cln = ((DSAwmoeglichkeiten)(base.Clone()));
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
            if ((ds.Tables["awmoeglichkeiten"] != null)) {
                this.Tables.Add(new awmoeglichkeitenDataTable(ds.Tables["awmoeglichkeiten"]));
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
            this.tableawmoeglichkeiten = ((awmoeglichkeitenDataTable)(this.Tables["awmoeglichkeiten"]));
            if ((this.tableawmoeglichkeiten != null)) {
                this.tableawmoeglichkeiten.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "DSAwmoeglichkeiten";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/DSAwmoeglichkeiten.xsd";
            this.Locale = new System.Globalization.CultureInfo("de-DE");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableawmoeglichkeiten = new awmoeglichkeitenDataTable();
            this.Tables.Add(this.tableawmoeglichkeiten);
        }
        
        private bool ShouldSerializeawmoeglichkeiten() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void awmoeglichkeitenRowChangeEventHandler(object sender, awmoeglichkeitenRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class awmoeglichkeitenDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnAwmID;
            
            private DataColumn columnr_FrageID;
            
            private DataColumn columnText;
            
            internal awmoeglichkeitenDataTable() : 
                    base("awmoeglichkeiten") {
                this.InitClass();
            }
            
            internal awmoeglichkeitenDataTable(DataTable table) : 
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
            
            internal DataColumn AwmIDColumn {
                get {
                    return this.columnAwmID;
                }
            }
            
            internal DataColumn r_FrageIDColumn {
                get {
                    return this.columnr_FrageID;
                }
            }
            
            internal DataColumn TextColumn {
                get {
                    return this.columnText;
                }
            }
            
            public awmoeglichkeitenRow this[int index] {
                get {
                    return ((awmoeglichkeitenRow)(this.Rows[index]));
                }
            }
            
            public event awmoeglichkeitenRowChangeEventHandler awmoeglichkeitenRowChanged;
            
            public event awmoeglichkeitenRowChangeEventHandler awmoeglichkeitenRowChanging;
            
            public event awmoeglichkeitenRowChangeEventHandler awmoeglichkeitenRowDeleted;
            
            public event awmoeglichkeitenRowChangeEventHandler awmoeglichkeitenRowDeleting;
            
            public void AddawmoeglichkeitenRow(awmoeglichkeitenRow row) {
                this.Rows.Add(row);
            }
            
            public awmoeglichkeitenRow AddawmoeglichkeitenRow(int r_FrageID, string Text) {
                awmoeglichkeitenRow rowawmoeglichkeitenRow = ((awmoeglichkeitenRow)(this.NewRow()));
                rowawmoeglichkeitenRow.ItemArray = new object[] {
                        null,
                        r_FrageID,
                        Text};
                this.Rows.Add(rowawmoeglichkeitenRow);
                return rowawmoeglichkeitenRow;
            }
            
            public awmoeglichkeitenRow FindByAwmID(int AwmID) {
                return ((awmoeglichkeitenRow)(this.Rows.Find(new object[] {
                            AwmID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                awmoeglichkeitenDataTable cln = ((awmoeglichkeitenDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new awmoeglichkeitenDataTable();
            }
            
            internal void InitVars() {
                this.columnAwmID = this.Columns["AwmID"];
                this.columnr_FrageID = this.Columns["r_FrageID"];
                this.columnText = this.Columns["Text"];
            }
            
            private void InitClass() {
                this.columnAwmID = new DataColumn("AwmID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnAwmID);
                this.columnr_FrageID = new DataColumn("r_FrageID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnr_FrageID);
                this.columnText = new DataColumn("Text", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnText);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnAwmID}, true));
                this.columnAwmID.AutoIncrement = true;
                this.columnAwmID.AllowDBNull = false;
                this.columnAwmID.ReadOnly = true;
                this.columnAwmID.Unique = true;
                this.columnr_FrageID.AllowDBNull = false;
            }
            
            public awmoeglichkeitenRow NewawmoeglichkeitenRow() {
                return ((awmoeglichkeitenRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new awmoeglichkeitenRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(awmoeglichkeitenRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.awmoeglichkeitenRowChanged != null)) {
                    this.awmoeglichkeitenRowChanged(this, new awmoeglichkeitenRowChangeEvent(((awmoeglichkeitenRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.awmoeglichkeitenRowChanging != null)) {
                    this.awmoeglichkeitenRowChanging(this, new awmoeglichkeitenRowChangeEvent(((awmoeglichkeitenRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.awmoeglichkeitenRowDeleted != null)) {
                    this.awmoeglichkeitenRowDeleted(this, new awmoeglichkeitenRowChangeEvent(((awmoeglichkeitenRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.awmoeglichkeitenRowDeleting != null)) {
                    this.awmoeglichkeitenRowDeleting(this, new awmoeglichkeitenRowChangeEvent(((awmoeglichkeitenRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveawmoeglichkeitenRow(awmoeglichkeitenRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class awmoeglichkeitenRow : DataRow {
            
            private awmoeglichkeitenDataTable tableawmoeglichkeiten;
            
            internal awmoeglichkeitenRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableawmoeglichkeiten = ((awmoeglichkeitenDataTable)(this.Table));
            }
            
            public int AwmID {
                get {
                    return ((int)(this[this.tableawmoeglichkeiten.AwmIDColumn]));
                }
                set {
                    this[this.tableawmoeglichkeiten.AwmIDColumn] = value;
                }
            }
            
            public int r_FrageID {
                get {
                    return ((int)(this[this.tableawmoeglichkeiten.r_FrageIDColumn]));
                }
                set {
                    this[this.tableawmoeglichkeiten.r_FrageIDColumn] = value;
                }
            }
            
            public string Text {
                get {
                    try {
                        return ((string)(this[this.tableawmoeglichkeiten.TextColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Der Wert kann nicht ermittelt werden, da er DBNull ist.", e);
                    }
                }
                set {
                    this[this.tableawmoeglichkeiten.TextColumn] = value;
                }
            }
            
            public bool IsTextNull() {
                return this.IsNull(this.tableawmoeglichkeiten.TextColumn);
            }
            
            public void SetTextNull() {
                this[this.tableawmoeglichkeiten.TextColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class awmoeglichkeitenRowChangeEvent : EventArgs {
            
            private awmoeglichkeitenRow eventRow;
            
            private DataRowAction eventAction;
            
            public awmoeglichkeitenRowChangeEvent(awmoeglichkeitenRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public awmoeglichkeitenRow Row {
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