/*
Copyright (c) 2014, RMIT Training
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this
  list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.

* Neither the name of CounterCompliance nor the names of its
  contributors may be used to endorse or promote products derived from
  this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Copyright (c) 2009, EBSCO Industries, Inc.
All rights reserved.
Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
•Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
•Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer 
 in the documentation and/or other materials provided with the distribution.
•Neither the name of EBSCO Industries, Inc. nor the names of its contributors may be used to endorse or promote products derived 
 from this software without specific prior written permission.
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
 * FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
 * INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS 
 * OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, 
 * EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
namespace Sushi.Client
{
   partial class MainForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
            this.label1 = new System.Windows.Forms.Label();
            this._serviceUri = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._requestorEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._requestorName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._requestorId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ShowAsTree = new System.Windows.Forms.CheckBox();
            this._customerName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._customerId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._dateRangeEnd = new System.Windows.Forms.DateTimePicker();
            this._dateRangeBegin = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this._reportRelease = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this._reportName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInvoke = new System.Windows.Forms.Button();
            this._status = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._response = new System.Windows.Forms.TreeView();
            this._responseDetails = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service Uri:";
            // 
            // _serviceUri
            // 
            this._serviceUri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._serviceUri.Location = new System.Drawing.Point(13, 30);
            this._serviceUri.Name = "_serviceUri";
            this._serviceUri.Size = new System.Drawing.Size(950, 20);
            this._serviceUri.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Response:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._requestorEmail);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this._requestorName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this._requestorId);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(13, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Requestor";
            // 
            // _requestorEmail
            // 
            this._requestorEmail.Location = new System.Drawing.Point(62, 70);
            this._requestorEmail.Name = "_requestorEmail";
            this._requestorEmail.Size = new System.Drawing.Size(231, 20);
            this._requestorEmail.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Email:";
            // 
            // _requestorName
            // 
            this._requestorName.Location = new System.Drawing.Point(62, 43);
            this._requestorName.Name = "_requestorName";
            this._requestorName.Size = new System.Drawing.Size(231, 20);
            this._requestorName.TabIndex = 3;
            this._requestorName.Text = "Sample Univerity";
            this._requestorName.TextChanged += new System.EventHandler(this._requestorName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Name:";
            // 
            // _requestorId
            // 
            this._requestorId.Location = new System.Drawing.Point(62, 17);
            this._requestorId.Name = "_requestorId";
            this._requestorId.Size = new System.Drawing.Size(231, 20);
            this._requestorId.TabIndex = 1;
            this._requestorId.Text = "1234";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "ID:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ShowAsTree);
            this.groupBox2.Controls.Add(this._customerName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this._customerId);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(323, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 100);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer Reference";
            // 
            // ShowAsTree
            // 
            this.ShowAsTree.AutoSize = true;
            this.ShowAsTree.Location = new System.Drawing.Point(62, 70);
            this.ShowAsTree.Name = "ShowAsTree";
            this.ShowAsTree.Size = new System.Drawing.Size(92, 17);
            this.ShowAsTree.TabIndex = 4;
            this.ShowAsTree.Text = "Show as Tree";
            this.ShowAsTree.UseVisualStyleBackColor = true;
            // 
            // _customerName
            // 
            this._customerName.Location = new System.Drawing.Point(62, 43);
            this._customerName.Name = "_customerName";
            this._customerName.Size = new System.Drawing.Size(231, 20);
            this._customerName.TabIndex = 3;
            this._customerName.Text = "guest";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Name:";
            // 
            // _customerId
            // 
            this._customerId.Location = new System.Drawing.Point(62, 17);
            this._customerId.Name = "_customerId";
            this._customerId.Size = new System.Drawing.Size(231, 20);
            this._customerId.TabIndex = 1;
            this._customerId.Text = "123ABC";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "ID:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._dateRangeEnd);
            this.groupBox3.Controls.Add(this._dateRangeBegin);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this._reportRelease);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this._reportName);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(13, 162);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(609, 76);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Report Definition";
            // 
            // _dateRangeEnd
            // 
            this._dateRangeEnd.Location = new System.Drawing.Point(372, 45);
            this._dateRangeEnd.Name = "_dateRangeEnd";
            this._dateRangeEnd.Size = new System.Drawing.Size(231, 20);
            this._dateRangeEnd.TabIndex = 10;
            this._dateRangeEnd.Value = new System.DateTime(2014, 2, 28, 0, 0, 0, 0);
            // 
            // _dateRangeBegin
            // 
            this._dateRangeBegin.Location = new System.Drawing.Point(372, 19);
            this._dateRangeBegin.Name = "_dateRangeBegin";
            this._dateRangeBegin.Size = new System.Drawing.Size(231, 20);
            this._dateRangeBegin.TabIndex = 9;
            this._dateRangeBegin.Value = new System.DateTime(2014, 2, 1, 0, 0, 0, 0);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(317, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "End:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(317, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Begin:";
            // 
            // _reportRelease
            // 
            this._reportRelease.Location = new System.Drawing.Point(62, 45);
            this._reportRelease.Name = "_reportRelease";
            this._reportRelease.Size = new System.Drawing.Size(231, 20);
            this._reportRelease.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Release:";
            // 
            // _reportName
            // 
            this._reportName.Location = new System.Drawing.Point(62, 19);
            this._reportName.Name = "_reportName";
            this._reportName.Size = new System.Drawing.Size(231, 20);
            this._reportName.TabIndex = 3;
            this._reportName.Text = "JR1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // btnInvoke
            // 
            this.btnInvoke.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvoke.Location = new System.Drawing.Point(875, 703);
            this.btnInvoke.Name = "btnInvoke";
            this.btnInvoke.Size = new System.Drawing.Size(88, 23);
            this.btnInvoke.TabIndex = 10;
            this.btnInvoke.Text = "Invoke Service";
            this.btnInvoke.UseVisualStyleBackColor = true;
            this.btnInvoke.Click += new System.EventHandler(this.OnInvokeService);
            // 
            // _status
            // 
            this._status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._status.AutoSize = true;
            this._status.Location = new System.Drawing.Point(13, 713);
            this._status.Name = "_status";
            this._status.Size = new System.Drawing.Size(24, 13);
            this._status.TabIndex = 11;
            this._status.Text = "Idle";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 257);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._response);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._responseDetails);
            this.splitContainer1.Size = new System.Drawing.Size(951, 440);
            this.splitContainer1.SplitterDistance = 146;
            this.splitContainer1.TabIndex = 12;
            // 
            // _response
            // 
            this._response.Dock = System.Windows.Forms.DockStyle.Fill;
            this._response.Location = new System.Drawing.Point(0, 0);
            this._response.Name = "_response";
            this._response.Size = new System.Drawing.Size(146, 440);
            this._response.TabIndex = 9;
            this._response.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnResponseSelectionChanged);
            // 
            // _responseDetails
            // 
            this._responseDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this._responseDetails.Location = new System.Drawing.Point(0, 0);
            this._responseDetails.Name = "_responseDetails";
            this._responseDetails.Size = new System.Drawing.Size(801, 440);
            this._responseDetails.TabIndex = 0;
            this._responseDetails.Text = "";
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnInvoke;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 738);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this._status);
            this.Controls.Add(this.btnInvoke);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._serviceUri);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(650, 480);
            this.Name = "MainForm";
            this.Text = "Sushi Service Client Simulator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox _serviceUri;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TextBox _requestorEmail;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.TextBox _requestorName;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox _requestorId;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.TextBox _customerName;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.TextBox _customerId;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.TextBox _reportRelease;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.TextBox _reportName;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.DateTimePicker _dateRangeEnd;
      private System.Windows.Forms.DateTimePicker _dateRangeBegin;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.Button btnInvoke;
      private System.Windows.Forms.Label _status;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.RichTextBox _responseDetails;
      private System.Windows.Forms.CheckBox ShowAsTree;
      private System.Windows.Forms.TreeView _response;
   }
}