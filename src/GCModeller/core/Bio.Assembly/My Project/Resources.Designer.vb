﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("SMRUCC.genomics.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to +E	Reaction
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt;&amp;nbsp; Enzymatic Reactions&lt;/h2&gt;
        '''!
        '''A&lt;b&gt;1. Oxidoreductase reactions&lt;/b&gt;
        '''B  1.1  Acting on the CH-OH group of donors
        '''C    1.1.1  With NAD+ or NADP+ as acceptor
        '''D      1.1.1.1
        '''E        R00623  Primary alcohol + NAD+ &lt;=&gt; Aldehyde + NADH + H+
        '''E        R00624  Secondary alcohol + NAD+ &lt;=&gt; Ketone + NADH + H+
        '''E        R00754  Ethanol + NAD+ &lt;=&gt; Acetaldehyde + NADH + H+
        '''E        R02124  Retinol + NAD+ &lt;=&gt;  [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property br08201() As String
            Get
                Return ResourceManager.GetString("br08201", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to +D	Reaction	Substrate	Product	Substrate2	Product2
        '''%&lt;style type=&quot;text/css&quot;&gt;&lt;!--#grid{table-layout:fixed;font-family:monospace;position:relative;color:black;width:1400px;}.col1{position:relative;background:white;z-index:1;overflow:hidden;width:200px;}.col2{position:relative;background:white;z-index:2;padding-left:10px;overflow:hidden;width:300px;}.col3{position:relative;background:white;z-index:3;padding-left:10px;overflow:hidden;width:300px;}.col4{position:relative;background:white;z-index:2;padding-left:10 [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property br08202() As String
            Get
                Return ResourceManager.GetString("br08202", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to +B	Glycosyltransferase reaction
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt; &amp;nbsp; Glycosyltransferase Reactions&lt;/h2&gt;
        '''!
        '''A&lt;b&gt;Glucosyltransferase reactions&lt;/b&gt;
        '''B  R06264  Glc a1-2 Glc [KO:K03850] [PATH:rn00510]
        '''B  R03118  Glc a1-3 Glc [KO:K00706] [PATH:rn00500]
        '''B  R06263  Glc a1-3 Glc [KO:K03849] [PATH:rn00510]
        '''B  R00292  Glc a1-4 Glc [KO:K00693] [PATH:rn00500]
        '''B  R06184  Glc a1-6 Glc
        '''B  R06018  Glc b1-3 Glc
        '''B  R01994  Glc a1-2 Gal [KO:K03276] [PATH:rn [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property br08203() As String
            Get
                Return ResourceManager.GetString("br08203", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to +E	RClass
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt;&amp;nbsp; Reaction Class&lt;/h2&gt;
        '''!
        '''A&lt;b&gt;1. Oxidoreductase reactions&lt;/b&gt;
        '''B  1.1  Acting on the CH-OH group of donors
        '''C    1.1.1  With NAD+ or NADP+ as acceptor
        '''D      1.1.1.1
        '''E        RC00050
        '''E        RC00087
        '''E        RC00088
        '''E        RC00099
        '''E        RC00116
        '''E        RC00649
        '''E        RC00955
        '''E        RC01734
        '''E        RC02273
        '''D      1.1.1.2
        '''E        RC00050
        '''E        RC00087
        '''E        RC00088
        '''E        RC00099
        '''E        [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property br08204() As String
            Get
                Return ResourceManager.GetString("br08204", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to +U
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt;&amp;nbsp; KEGG Organisms in the NCBI Taxonomy&lt;/h2&gt;
        '''#&lt;!---
        '''#ENTRY       br08610
        '''#DEFINITION  KEGG Organisms in the NCBI taxonomy
        '''#---&gt;
        '''!
        '''AEukaryota
        '''B  Metazoa
        '''C    Chordata
        '''D      Craniata
        '''E        Vertebrata
        '''F          Euteleostomi
        '''G            Mammalia
        '''H              Eutheria
        '''I                Euarchontoglires
        '''J                  Primates
        '''K                    Haplorrhini
        '''L                      Catarrh [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property br08610() As String
            Get
                Return ResourceManager.GetString("br08610", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to +C	Map number
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt;&amp;nbsp; KEGG Pathway Maps&lt;/h2&gt;
        '''!
        '''A&lt;b&gt;Metabolism&lt;/b&gt;
        '''B  Global and overview maps
        '''C    01100  Metabolic pathways
        '''C    01110  Biosynthesis of secondary metabolites
        '''C    01120  Microbial metabolism in diverse environments
        '''C    01130  Biosynthesis of antibiotics
        '''C    01200  Carbon metabolism
        '''C    01210  2-Oxocarboxylic acid metabolism
        '''C    01212  Fatty acid metabolism
        '''C    01230  Biosynthesis of amino acids
        '''C  [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property br08901() As String
            Get
                Return ResourceManager.GetString("br08901", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to +D	KO
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt; &amp;nbsp; KEGG Orthology (KO) - All Categories&lt;/h2&gt;
        '''!
        '''A09100 Metabolism
        '''B
        '''B  09101 Carbohydrate metabolism
        '''C    00010 Glycolysis / Gluconeogenesis [PATH:ko00010]
        '''D      K00844  HK; hexokinase
        '''D      K12407  GCK; glucokinase
        '''D      K00845  glk; glucokinase
        '''D      K01810  GPI, pgi; glucose-6-phosphate isomerase
        '''D      K06859  pgi1; glucose-6-phosphate isomerase, archaeal
        '''D      K13810  tal-pgi; transaldo [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property ko00000() As String
            Get
                Return ResourceManager.GetString("ko00000", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to +D	KO
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt; &amp;nbsp; KEGG Orthology (KO)&lt;/h2&gt;
        '''!
        '''A09100 Metabolism
        '''B
        '''B  09101 Carbohydrate metabolism
        '''C    00010 Glycolysis / Gluconeogenesis [PATH:ko00010]
        '''D      K00844  HK; hexokinase [EC:2.7.1.1]
        '''D      K12407  GCK; glucokinase [EC:2.7.1.2]
        '''D      K00845  glk; glucokinase [EC:2.7.1.2]
        '''D      K01810  GPI, pgi; glucose-6-phosphate isomerase [EC:5.3.1.9]
        '''D      K06859  pgi1; glucose-6-phosphate isomerase, archaeal [EC:5.3.1. [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property ko00001() As String
            Get
                Return ResourceManager.GetString("ko00001", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to +E	Module
        '''#&lt;h2&gt;&lt;a href=&quot;/kegg/kegg2.html&quot;&gt;&lt;img src=&quot;/Fig/bget/kegg3.gif&quot; align=&quot;middle&quot; border=0&gt;&lt;/a&gt;&amp;nbsp; KEGG Modules&lt;/h2&gt;
        '''!
        '''A&lt;b&gt;Pathway module&lt;/b&gt;
        '''B
        '''B  &lt;b&gt;Energy metabolism&lt;/b&gt;
        '''C    Carbon fixation
        '''D      M00165  Reductive pentose phosphate cycle (Calvin cycle) [PATH:map00710 map01200 map01100 map01120]
        '''E        K00855  PRK, prkB; phosphoribulokinase [EC:2.7.1.19]
        '''E        K01601  rbcL; ribulose-bisphosphate carboxylase large chain [EC:4.1.1.39]
        '''E        K01602  rbcS; ribulose-bisphosphate car [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property ko00002_keg() As String
            Get
                Return ResourceManager.GetString("ko00002_keg", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Pfam AccessionId,Signaling domain ID,Domain name,Kind,Function,Marker
        '''PF01339,CheB_methylest,CheB_methylest,chemotaxis,Chemotaxis,Yes
        '''PF04509,CheC,CheC,chemotaxis,Chemotaxis,Yes
        '''PF03975,CheD,CheD,chemotaxis,Chemotaxis,Yes
        '''PF01739,CheR,CheR,chemotaxis,Chemotaxis,Yes
        '''PF03705,CheR_N,CheR_N,chemotaxis,Chemotaxis,Yes
        '''PF01584,CheW,CheW,chemotaxis,Chemotaxis,Yes
        '''PF09078,CheY-binding,CheY-binding,chemotaxis,Chemotaxis,Yes
        '''PF04344,CheZ,CheZ,chemotaxis,Chemotaxis,Yes
        '''PF02895,H-kinase_dim,H-kinase_dim,chemota [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property MiST2() As String
            Get
                Return ResourceManager.GetString("MiST2", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Test.
        '''</summary>
        Friend ReadOnly Property String1() As String
            Get
                Return ResourceManager.GetString("String1", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to transl_table=1
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA * Ter  
        '''TTG L Leu i    TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu i    CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr   [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property transl_table_1() As String
            Get
                Return ResourceManager.GetString("transl_table_1", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to transl_table=10
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA C Cys  
        '''TTG L Leu      TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr  [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property transl_table_10() As String
            Get
                Return ResourceManager.GetString("transl_table_10", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to transl_table=11
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA * Ter  
        '''TTG L Leu i    TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu i    CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile i    ACT T Thr  [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property transl_table_11() As String
            Get
                Return ResourceManager.GetString("transl_table_11", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to transl_table=12
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA * Ter  
        '''TTG L Leu      TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG S Ser i    CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr  [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property transl_table_12() As String
            Get
                Return ResourceManager.GetString("transl_table_12", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to transl_table=13
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA W Trp  
        '''TTG L Leu i    TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr  [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property transl_table_13() As String
            Get
                Return ResourceManager.GetString("transl_table_13", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to transl_table=14
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA Y Tyr      TGA W Trp  
        '''TTG L Leu      TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr  [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property transl_table_14() As String
            Get
                Return ResourceManager.GetString("transl_table_14", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to transl_table=16
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA * Ter  
        '''TTG L Leu      TCG S Ser      TAG L Leu      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr  [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property transl_table_16() As String
            Get
                Return ResourceManager.GetString("transl_table_16", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to transl_table=2
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA W Trp  
        '''TTG L Leu      TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile i    ACT T Thr   [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property transl_table_2() As String
            Get
                Return ResourceManager.GetString("transl_table_2", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to transl_table=21
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA W Trp  
        '''TTG L Leu      TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr  [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property transl_table_21() As String
            Get
                Return ResourceManager.GetString("transl_table_21", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to transl_table=22
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA * Ter      TAA * Ter      TGA * Ter  
        '''TTG L Leu      TCG S Ser      TAG L Leu      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr  [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property transl_table_22() As String
            Get
                Return ResourceManager.GetString("transl_table_22", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to transl_table=23
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA * Ter      TCA S Ser      TAA * Ter      TGA * Ter  
        '''TTG L Leu      TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile i    ACT T Thr  [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property transl_table_23() As String
            Get
                Return ResourceManager.GetString("transl_table_23", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to transl_table=24
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA W Trp  
        '''TTG L Leu i    TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu i    CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr  [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property transl_table_24() As String
            Get
                Return ResourceManager.GetString("transl_table_24", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to transl_table=25
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA G Gly  
        '''TTG L Leu i    TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr  [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property transl_table_25() As String
            Get
                Return ResourceManager.GetString("transl_table_25", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to transl_table=3
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA W Trp  
        '''TTG L Leu      TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT T Thr      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC T Thr      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA T Thr      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG T Thr      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr   [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property transl_table_3() As String
            Get
                Return ResourceManager.GetString("transl_table_3", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to transl_table=4
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu i    TCA S Ser      TAA * Ter      TGA W Trp  
        '''TTG L Leu i    TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu i    CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile i    ACT T Thr   [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property transl_table_4() As String
            Get
                Return ResourceManager.GetString("transl_table_4", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to transl_table=5
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA W Trp  
        '''TTG L Leu i    TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile i    ACT T Thr   [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property transl_table_5() As String
            Get
                Return ResourceManager.GetString("transl_table_5", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to transl_table=6
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA Q Gln      TGA * Ter  
        '''TTG L Leu      TCG S Ser      TAG Q Gln      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr   [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property transl_table_6() As String
            Get
                Return ResourceManager.GetString("transl_table_6", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to transl_table=9
        '''
        '''TTT F Phe      TCT S Ser      TAT Y Tyr      TGT C Cys  
        '''TTC F Phe      TCC S Ser      TAC Y Tyr      TGC C Cys  
        '''TTA L Leu      TCA S Ser      TAA * Ter      TGA W Trp  
        '''TTG L Leu      TCG S Ser      TAG * Ter      TGG W Trp  
        '''
        '''CTT L Leu      CCT P Pro      CAT H His      CGT R Arg  
        '''CTC L Leu      CCC P Pro      CAC H His      CGC R Arg  
        '''CTA L Leu      CCA P Pro      CAA Q Gln      CGA R Arg  
        '''CTG L Leu      CCG P Pro      CAG Q Gln      CGG R Arg  
        '''
        '''ATT I Ile      ACT T Thr   [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property transl_table_9() As String
            Get
                Return ResourceManager.GetString("transl_table_9", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
