using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace NovelStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            NovelStoreDbContext context =
           app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService < NovelStoreDbContext > ();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Novels.Any())
            {
                context.Novels.AddRange(
                new Novel
                {
                    Title = "Sherlock Holmes",
                    Author = "Arthur Conan Doyle",
                    Description = "Đây là cuốn tiểu thuyết vô cùng hấp dẫn với những câu chuyện đặc sắc, khiến người xem 'nghẹt thở' đến giây phút cuối cùng. Quyển sách xuất bản lần đầu tiên vào năm 1887, cho đến nay Sherlock Holmes Conan Doyle  đã trở thành một tượng đài bất tử trong làng truyện trinh thám.",
                    Genre = "Trinh Thám",
                    Price = 11.98m
                },
                new Novel
                {
                    Title = "Đề thi đẫm máu",
                    Author = "Lôi Mễ",
                    Description = "Với những vụ án rùng rợn, kinh dị và khủng khiếp qua ngòi bút sắc bén của tác giả Lôi Mễ, “Đề thi đẫm máu” đã trở thành một trong những cuốn tiểu thuyết trinh thám nổi tiếng nhất trên thế giới thu hút được sự quan tâm của hàng triệu độc giả.  Cuốn tiểu thuyết này không đơn thuần là những vụ án khủng khiếp, mà còn là những trăn trở, suy nghĩ về tâm lí nhân vật, về những triết lí trong cuộc sống.",
                    Genre = "Trinh Thám - Kinh Dị",
                    Price = 17.46m
                },
                new Novel
                {
                    Title = "Ring - Vòng tròn ác nghiệt",
                    Author = "Suzuki Kōji",
                    Description = "Ring - Vòng tròn ác nghiệt là tên tiểu thuyết kinh dị, bí ẩn của nhà văn người Nhật Suzuki Kōji xuất bản lần đầu năm 1991. Ring được xem là một trong những đỉnh cao thể loại văn học kinh dị của Nhật, tạo nên cơn sốt kinh dị tại Nhật suốt một thời gian dài.",
                    Genre = "Kinh Dị",
                    Price = 13.41m
                },
                new Novel
                {
                    Title = "Eragon – Cậu Bé Cưỡi Rồng",
                    Author = "Christopher Paolini",
                    Description = "Tình cờ trong một lần đi săn, Eragon nhặt được một viên đá màu xanh. Tưởng đây là điều may mắn dành cho một đứa trẻ nông dân nghèo khổ như nó, nhưng viên đá, thật ra là một trứng rồng, đã nở ra một rồng con.",
                    Genre = "Giả Tưởng",
                    Price = 18.69m
                },
                new Novel
                {
                    Title = "Cỗ Máy Thời Gian",
                    Author = "Herbert George Wells",
                    Description = "Nhân vật chính trong Cỗ máy Thời Gian, bằng phát minh khoa học của mình, đã đến tương lai xa xôi năm 802701 và dấn thân vào cuộc hành trình đi tìm câu trả lời về số phận của nhân loại.",
                    Genre = "Hư Cấu Hiện Thực",
                    Price = 31.26m
                }
                );
                context.SaveChanges();
            }
        }
    }
}