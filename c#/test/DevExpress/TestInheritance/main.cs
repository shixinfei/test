﻿#define TEST_INHERITANCE
//#define SHOW_ATTRIBUTES
//#define TEST_SINGLE_TABLE
//#define TEST_OWN_TABLE

using System;
using System.Linq;
using System.Reflection;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using TestInheritance.Db;

namespace TestInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DevExpress.Xpo.Metadata.ReflectionClassInfo.SuppressSuspiciousMemberInheritanceCheck = true;

                XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString("i-nozhenko", "sa", "123", "testdb");
                //XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString("NOZHENKO-I-XP\\SQLEXPRESS", "testdb");
                
                using (var session = new Session())
                {
					#if TEST_INHERITANCE
                        StuSKU
                            sku;

                        if ((sku = session.GetObjectByKey<StuSKU>(1)) != null)
                        { 
                            foreach (StuSKUCompetitorByGood item in sku.StuSKUCopetitorByGood)
                                Console.WriteLine("{{id:{0}, SKU.id:{1} (\"{3}\"), SKUCompetitor.id:{2} (\"{4}\")}}", item.id, item.SKU != null ? item.SKU.id.ToString() : "null", item.SKUCompetitor != null ? item.SKUCompetitor.id.ToString() : "null", item.SKU != null ? item.SKU.FullName : "null", item.SKUCompetitor != null ? item.SKUCompetitor.FullName : "null");
                            Console.WriteLine(new string('-', 60));

                            foreach (StuSKUCompetitorByGood item in sku.StuSKUCopetitorByCopetitor)
                                Console.WriteLine("{{id:{0}, SKU.id:{1} (\"{3}\"), SKUCompetitor.id:{2} (\"{4}\")}}", item.id, item.SKU != null ? item.SKU.id.ToString() : "null", item.SKUCompetitor != null ? item.SKUCompetitor.id.ToString() : "null", item.SKU != null ? item.SKU.FullName : "null", item.SKUCompetitor != null ? item.SKUCompetitor.FullName : "null");
                            Console.WriteLine(new string('-', 60));
                        }
                        Console.WriteLine();

                        if ((sku = session.GetObjectByKey<StuSKU>(3)) != null)
                        {
                            foreach (StuSKUCompetitorByGood item in sku.StuSKUCopetitorByGood)
                                Console.WriteLine("{{id:{0}, SKU.id:{1} (\"{3}\"), SKUCompetitor.id:{2} (\"{4}\")}}", item.id, item.SKU != null ? item.SKU.id.ToString() : "null", item.SKUCompetitor != null ? item.SKUCompetitor.id.ToString() : "null", item.SKU != null ? item.SKU.FullName : "null", item.SKUCompetitor != null ? item.SKUCompetitor.FullName : "null");
                            Console.WriteLine(new string('-', 60));

                            foreach (StuSKUCompetitorByGood item in sku.StuSKUCopetitorByCopetitor)
                                Console.WriteLine("{{id:{0}, SKU.id:{1} (\"{3}\"), SKUCompetitor.id:{2} (\"{4}\")}}", item.id, item.SKU != null ? item.SKU.id.ToString() : "null", item.SKUCompetitor != null ? item.SKUCompetitor.id.ToString() : "null", item.SKU != null ? item.SKU.FullName : "null", item.SKUCompetitor != null ? item.SKUCompetitor.FullName : "null");
                            Console.WriteLine(new string('-', 60));
                        }
                        Console.WriteLine();

                        StuSKUCompetitorByGood
                            skuCompetitorByGood;

                        if ((skuCompetitorByGood = new StuSKUCompetitorByGood(session)) != null)
                        {
                            skuCompetitorByGood.SKU = session.GetObjectByKey<StuSKU>(2);
                            skuCompetitorByGood.SKUCompetitor = session.GetObjectByKey<StuSKU>(5);
                            skuCompetitorByGood.Value = $"{{STU:'{skuCompetitorByGood.SKU.FullName}', SKUCompetitor:'{skuCompetitorByGood.SKUCompetitor.FullName}'}}";
                            skuCompetitorByGood.Save();
                            session.Save(skuCompetitorByGood);
                        }

                        ShowProperties(typeof(ForTestInheritanceIIBackward));

						Reference
							left = session.GetObjectByKey<Reference>(1),
							right = session.GetObjectByKey<Reference>(2);

						ForTestInheritanceII
							forTestInheritanceII = new ForTestInheritanceII(session);

						forTestInheritanceII.Left = left;
						forTestInheritanceII.Right = right;
						forTestInheritanceII.Value = string.Format("{{Left:'{0}', Right:'{1}'}}", forTestInheritanceII.Left.Value, forTestInheritanceII.Right.Value);
						forTestInheritanceII.Save();
						session.Save(forTestInheritanceII);

						ForTestInheritanceIIBackward
							forTestInheritanceIIBackward = new ForTestInheritanceIIBackward(session);

						forTestInheritanceIIBackward.Left = left;
						forTestInheritanceIIBackward.Right = right;
						forTestInheritanceIIBackward.Value = string.Format("{{Left:'{0}', Right:'{1}'}}", forTestInheritanceIIBackward.Left.Value, forTestInheritanceIIBackward.Right.Value);
						forTestInheritanceIIBackward.Save();
						session.Save(forTestInheritanceIIBackward);

						ForTestInheritanceILeftRight
							forTestInheritanceILeftRight = session.GetObjectByKey<ForTestInheritanceILeftRight>(1);

						ForTestInheritanceIRightLeft
							forTestInheritanceIRightLeft = session.GetObjectByKey<ForTestInheritanceIRightLeft>(2);

						ShowReference(session.GetObjectByKey<Reference>(1));
						ShowReference(session.GetObjectByKey<Reference>(2));

						left = new Reference(session);
						left.Value = string.Format("Link# {0}", session.GetObjects(session.GetClassInfo<Reference>(), null, null, 0, true, true).Count + 1);
						left.Save();
						session.Save(left);

						right = new Reference(session);
						right.Value = string.Format("Link# {0}", session.GetObjects(session.GetClassInfo<Reference>(), null, null, 0, true, true).Count + 1);
						right.Save();
						session.Save(right);

						forTestInheritanceILeftRight = new ForTestInheritanceILeftRight(session);
						forTestInheritanceILeftRight.Left = left;
						forTestInheritanceILeftRight.Right = right;
						forTestInheritanceILeftRight.Value = string.Format("{{Left:'{0}', Right:'{1}'}}", forTestInheritanceILeftRight.Left.Value, forTestInheritanceILeftRight.Right.Value);
						forTestInheritanceILeftRight.Save();
						session.Save(forTestInheritanceILeftRight);

						forTestInheritanceIRightLeft = new ForTestInheritanceIRightLeft(session);
						forTestInheritanceIRightLeft.Left = left;
						forTestInheritanceIRightLeft.Right = right;
						forTestInheritanceIRightLeft.Value = string.Format("{{Left:'{0}', Right:'{1}'}}", forTestInheritanceIRightLeft.Left.Value, forTestInheritanceIRightLeft.Right.Value);
						forTestInheritanceIRightLeft.Save();
						session.Save(forTestInheritanceIRightLeft);
					#endif

                    #if TEST_SINGLE_TABLE
                        #if SHOW_ATTRIBUTES
                            var ci = session.GetClassInfo<TestDEDetailTableWithInheritanceLite>();
                            var mi = ci.GetMember("Master");
                            foreach (var attribute in mi.Attributes)
                            {
                                if (attribute is PersistentAttribute)
                                    Console.WriteLine("{0}: MapTo = \"{1}\"", attribute.GetType().Name, (attribute as PersistentAttribute).MapTo);
                                if (attribute is AssociationAttribute)
                                    Console.WriteLine("{0}: Name = \"{1}\"", attribute.GetType().Name, (attribute as AssociationAttribute).Name);
                            }

                            ci = session.GetClassInfo<TestDEDetailTableWithInheritance>();
                            mi = ci.GetMember("Master");
                            foreach (var attribute in mi.Attributes)
                            {
                                if (attribute is PersistentAttribute)
                                    Console.WriteLine("{0}: MapTo = \"{1}\"", attribute.GetType().Name, (attribute as PersistentAttribute).MapTo);
                                if (attribute is AssociationAttribute)
                                    Console.WriteLine("{0}: Name = \"{1}\"", attribute.GetType().Name, (attribute as AssociationAttribute).Name);
                            }

                            ci = session.GetClassInfo<TestDEMasterTableWithInheritanceLite>();

                            foreach (var m in ci.OwnMembers)
                                Console.WriteLine(m.Name);

                            mi = ci.GetMember("Details");
                            foreach (var attribute in mi.Attributes)
                            {
                                if (attribute is AssociationAttribute)
                                    Console.WriteLine("{0}: Name = \"{1}\"", attribute.GetType().Name, (attribute as AssociationAttribute).Name);
                            }

                            ci = session.GetClassInfo<TestDEMasterTableWithInheritance>();

                            foreach (var m in ci.OwnMembers)
                                Console.WriteLine(m.Name);

                            mi = ci.GetMember("Details");
                            foreach (var attribute in mi.Attributes)
                            {
                                if (attribute is AssociationAttribute)
                                    Console.WriteLine("{0}: Name = \"{1}\"", attribute.GetType().Name, (attribute as AssociationAttribute).Name);
                            }

                            var tmpType = typeof (TestDEMasterTableWithInheritance);
                            var rmi = tmpType.GetMember("Details", BindingFlags.Public | BindingFlags.Instance);
                        #endif

                        Console.WriteLine("TestDEMasterTableWithInheritanceLite.IsAssignableFrom(TestDEMasterTableWithInheritance) (TestDEMasterTableWithInheritanceLite->TestDEMasterTableWithInheritance): {0}", typeof(TestDEMasterTableWithInheritanceLite).IsAssignableFrom(typeof(TestDEMasterTableWithInheritance))); // true
                        Console.WriteLine("TestDEMasterTableWithInheritance.IsAssignableFrom(TestDEMasterTableWithInheritanceLite) (TestDEMasterTableWithInheritance->TestDEMasterTableWithInheritanceLite): {0}", typeof(TestDEMasterTableWithInheritance).IsAssignableFrom(typeof(TestDEMasterTableWithInheritanceLite))); // false

                        TestDEMasterTableWithInheritanceLite masterLite;
                        TestDEDetailTableWithInheritanceLite detailLite;
                        TestDEMasterTableWithInheritance master;
                        TestDEDetailTableWithInheritance detail;

                        int key = 1;

                        if ((masterLite = session.GetObjectByKey<TestDEMasterTableWithInheritanceLite>(key)) == null)
                        {
                            masterLite = new TestDEMasterTableWithInheritanceLite(session);
                            masterLite.ValueLite = "ValueLite (from masterLite) by new ()";
                        }
                        else
                            masterLite.ValueLite = "ValueLite (from masterLite) by edit";

                        detailLite = new TestDEDetailTableWithInheritanceLite(session);
                        detailLite.ValueLite = "ValueLite (from detailLite) by new ()";
                        masterLite.Details.Add(detailLite);
                        masterLite.Save();

                        try
                        {
                            master = session.GetObjectByKey<TestDEMasterTableWithInheritance>(key);
                        }
                        catch (Exception eException)
                        {
                            Console.WriteLine("{0}: \"{1}\"", eException.GetType().Name, eException.Message);
                        }

                        key += 1;
                        if ((master = session.GetObjectByKey<TestDEMasterTableWithInheritance>(key)) == null)
                        {
                            master = new TestDEMasterTableWithInheritance(session);
                            master.ValueLite = "ValueLite (from master) by new()";
                            master.Value = "Value (from master) by new()";
                        }
                        else
                        {
                            master.ValueLite = "ValueLite (from master) by edit";
                            master.Value = "Value (from master) by edit";
                        }

                        detail =new TestDEDetailTableWithInheritance(session);
                        detail.ValueLite = "ValueLite (from detail) by new ()";
                        detail.Value = "Value (from detail) by new ()";
                        detail.Master = master;
                        //master.Details.Add(detail);
                        master.Save();

                        Console.WriteLine();
                        if((masterLite = session.GetObjectByKey<TestDEMasterTableWithInheritanceLite>(key)) != null)
                        {
                            Console.WriteLine("masterLite {{id: {0}, valueLite: \"{1}\"}}", masterLite.Id, masterLite.ValueLite);
                            Console.WriteLine("Details");
                            /*foreach (var _detail_ in masterLite.Details)
                                Console.WriteLine("id: {0}, valueLite: \"{1}\"", _detail_.Id, _detail_.ValueLite);*/
                        }
                    #endif

                    #if TEST_OWN_TABLE
                        Left left;
                        Right right;

                        if ((left = session.GetObjectByKey<Left>(1)) == null)
                        {
                            left = new Left(session);
                            left.Val = "Val (from Left)";
                            left.ValLeft = "ValLeft";
                            left.Save();
                        }

                        if ((right = session.GetObjectByKey<Right>(1)) == null)
                        {
                            right = new Right(session);
                            right.Val = "Val (from Right)";
                            right.ValRight = "ValRight";
                            right.Save();
                        }

                        if (left != null && session.IsObjectToSave(left))
                            left.Save();

                        if (right != null && session.IsObjectToSave(right))
                            right.Save();
                    #endif
                }
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }

		#if TEST_INHERITANCE
			static void ShowReference(Reference reference)
			{
				if (reference == null)
				{
					Console.WriteLine("null");
					return;
				}

				foreach (var item in reference.ForTestInheritanceILeftRightLeft.OfType<ForTestInheritanceILeftRight>())
					Console.WriteLine("{{Id:{0}, Value:\"{1}\"}}", item.Id, item.Value);

				foreach (var item in reference.ForTestInheritanceILeftRightRight.OfType<ForTestInheritanceILeftRight>())
					Console.WriteLine("{{Id:{0}, Value:\"{1}\"}}", item.Id, item.Value);

				foreach (var item in reference.ForTestInheritanceIRightLeftLeft.OfType<ForTestInheritanceIRightLeft>())
					Console.WriteLine("{{Id:{0}, Value:\"{1}\"}}", item.Id, item.Value);

				foreach (var item in reference.ForTestInheritanceIRightLeftRight.OfType<ForTestInheritanceIRightLeft>())
					Console.WriteLine("{{Id:{0}, Value:\"{1}\"}}", item.Id, item.Value);
			}

			static void ShowProperties(Type type)
			{
				var pis = type.GetProperties();

				foreach (var pi in pis)
				{
					Console.WriteLine(pi.Name);

					var attrs = pi.GetCustomAttributes(typeof(PersistentAttribute), true);
					if (attrs.Length > 0)
						Console.WriteLine("MapTo: \"{0}\"", ((PersistentAttribute)attrs[0]).MapTo);

					attrs = pi.GetCustomAttributes(typeof(PersistentAttribute), false);
					if (attrs.Length > 0)
						Console.WriteLine("MapTo: \"{0}\"", ((PersistentAttribute)attrs[0]).MapTo);

					attrs = pi.GetCustomAttributes(typeof(AssociationAttribute), true);
					if (attrs.Length > 0)
						Console.WriteLine("Name: \"{0}\"", ((AssociationAttribute)attrs[0]).Name);

					attrs = pi.GetCustomAttributes(typeof(AssociationAttribute), false);
					if (attrs.Length > 0)
						Console.WriteLine("Name: \"{0}\"", ((AssociationAttribute)attrs[0]).Name);
				}
			}
		#endif
    }
}
