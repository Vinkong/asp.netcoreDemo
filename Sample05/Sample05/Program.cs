using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Sample05
{
    class Program
    {
        static void Main(string[] args)
        {

            //测试插入单条数据
            //var content = new Content
            //{
            //    title = "标题1",
            //    content = "内容1",

            //};


            using (var conn = new SqlConnection("Data Source=192.168.13.50\\SERVICE;User ID=sa;Password=123456;Initial Catalog=TimeRecord;Pooling=true;Max Pool Size=100;"))
            {
                //                string sql_insert = @"INSERT INTO [Content]
                //                (title, [content], status, add_time, modify_time)
                //VALUES   (@title,@content,@status,@add_time,@modify_time)";
                //                var result = conn.Execute(sql_insert, content);
                //                Console.WriteLine($"test_insert：插入了{result}条数据！");
                //                Console.ReadKey();



                //测试一次插入两条数据
                //List<Content> list = new List<Content>()

                //{

                //    new Content{ title="kfz" ,content="test kfz"},
                //    new Content{ title="vinkong",content="vingkong test"},
                //};
                //string sql = "insert into content (title,content,status,add_time,modify_time) values(@title,@content,@status,@add_time,@modify_time) ";

                //var result = conn.Execute(sql, list);

                //Console.WriteLine($"test_mulit_insert:插入了{result}条数据！");




                //测试删除单条数据
                //var content2 = new Content { id = 2 };

                //string sql = "delete  from content where id=@id";
                //var result =conn.Execute(sql, content2);
                //Console.WriteLine($" test_del：删除了{result}条数据" );
                //Console.ReadKey();

                //测试删除多条数据
                //     List<Content> list = new List<Content>() {

                //         new Content{
                //             id=3,
                //         },
                //         new Content{
                //             id=4,
                //         },



                //     };
                //     string sql = "delete from content where id =@id";
                //int result =     conn.Execute(sql, list);

                //     Console.WriteLine($"test_mult_del:删除了{result}条数据！");
                //     Console.ReadKey();


                //修改单条数据

                //var ct = new Content {
                //    id = 1,
                //    title = "自愈我的伤",
                //    content ="嚣张"
                //};
                //string sql = "update  content  set title=@title,content=@content,modify_time=GETDATE() where id=@id";
                //int result = conn.Execute(sql, ct);

                //Console.WriteLine($"test_update修改le{result}数据");
                //Console.ReadKey();

                //修改多条数据

                //List<Content> list = new List<Content>() {

                //    new Content{id=5,title="孔凡中修改第一次",content="怎么了" },
                //    new Content{id=6,title="vinkong批量修改",content="我们不适合"}
                //};
                //string sql = "update  content  set title=@title,content=@content,modify_time=GETDATE() where id=@id";
                //int result = conn.Execute(sql, list);

                //Console.WriteLine($"test_mult_update修改了{result}条数据");
                //Console.ReadKey();
                //查询单条指定的数据
                //string sql = "select * from content where id=@id";
                //var  result = conn.Query<Content>(sql, new { id = 1 });
                //foreach (var item in result)
                //{
                //    Console.WriteLine(item.id+"======"+item.content+"======"+item.title);
                //}
                //Console.ReadKey();
                //查询多条指定的数据
                //string sql = "select * from content where id in @ids";
                //var result = conn.Query<Content>(sql, new { ids = new int[] { 5, 6 } });
                //foreach (var item in result)
                //{
                //    Console.WriteLine(item.id + "======" + item.content + "======" + item.title);
                //}
                //Console.ReadKey();
                string sql = "select * from content where id=@id;select * from comment where content_id=@id";

                using (var result =conn.QueryMultiple(sql,new { id=5}))
                {
                    var content = result.ReadFirstOrDefault<Content>();
                    content.comments = result.Read<Comment>();
                    Console.WriteLine($"test_select_content_with_comment:内容5的评论数量{(content.comments).Count()}");
                    Console.ReadKey();
                }

            }
        }




        }
    }
