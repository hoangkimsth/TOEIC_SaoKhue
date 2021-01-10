$(document).ready(function () {
    $('#dangky').submit(function (e) {
        $.ajax({
            url: '/DangKy/DangKy',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    alert("Đăng ký thành công!");
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('.huydk').submit(function (e) {
        $.ajax({
            url: '/DangKy/Huy',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    alert("Hủy đăng ký thành công!");
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('#themhv').submit(function (e) {
        $.ajax({
            url: '/HocVien/Them',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    alert("Lưu thông tin học viên thành công!");
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('#thu_hocphidk').submit(function (e) {
        $.ajax({
            url: '/HoaDon/ThuHocPhiDangKy_2',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    location = '/HoaDon/Xem?hoadon=' + response.hoadon;
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('#dangnhap').submit(function (e) {
        $.ajax({
            url: '/TaiKhoan/DangNhap_2',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    location = '/Home/Index';
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('#them-gv').submit(function (e) {
        $.ajax({
            url: '/GiaoVien/Them',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    alert("Lưu thông tin giáo viên thành công!");
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('.capnhat-gv').click(function () {
        var data = this.value.split("|");
        $('#capnhat-magv').val(data[0]);
        $('#capnhat-tengv').val(data[1]);
        $('#capnhat-sdtgv').val(data[2]);
        $('#capnhat-gv').show();
        $('#them-gv').hide();
    });
    $('#capnhat-gv').submit(function (e) {
        $.ajax({
            url: '/GiaoVien/CapNhat',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    alert("Cập nhật thông tin giáo viên thành công!");
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('.xoa-gv').submit(function (e) {
        $.ajax({
            url: '/GiaoVien/Xoa',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {                
                if (response.success) {
                    alert("Xóa thông tin giáo viên thành công!");
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
                
            }
        });
        e.preventDefault();
    });
    $('#them-ch').submit(function (e) {
        $.ajax({
            url: '/CaHoc/Them',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    alert("Thêm ca học thành công!");
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('.xoa-ch').submit(function (e) {
        $.ajax({
            url: '/CaHoc/Xoa',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    alert("Xóa ca học thành công!");
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {

            }
        });
        e.preventDefault();
    });
    $('#them-ct').submit(function (e) {
        $.ajax({
            url: '/ChuongTrinh/Them',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    alert("Thêm chương trình học thành công!");
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('.capnhat-ct').click(function () {
        var data = this.value.split("|");
        $('#capnhat-mact').val(data[0]);
        $('#capnhat-tenct').val(data[1]);
        $('#capnhat-thoigianhoc').val(data[2]);
        $('#capnhat-hocphi').val(data[3]);
        $('#capnhat-ct').show();
        $('#them-ct').hide();
    });
    $('#capnhat-ct').submit(function (e) {
        $.ajax({
            url: '/ChuongTrinh/CapNhat',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    alert("Cập nhật chương trình học thành công!");
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('#molop').submit(function (e) {
        $.ajax({
            url: '/Lop/Them_2',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    location = '/Lop/Index';
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('.huy-lop').submit(function (e) {
        $.ajax({
            url: '/Lop/Xoa',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    alert("Hủy lớp thành công!");
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('.baoluu').submit(function (e) {
        $.ajax({
            url: '/Lop/BaoLuu',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('.huybaoluu').submit(function (e) {
        $.ajax({
            url: '/Lop/BaoLuu',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('#hoadon-mahv').change(function () {
        var mahv = this.value;
        $.ajax({
            url: '/HocVien/Tim',
            data: { mahv },
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    $('#hoadon-tenhv').html(response.tenhv);
                    $('#hoadon-sdthv').html(response.sdt);
                    $('#hoadon-hocvien').show();
                }
                else {
                    alert("Không tìm thấy học viên có mã " + mahv);
                    $('#hoadon-hocvien').hide();
                }
            }, error: function () {
            }
        });
    });
    $('#hoadon-malop').change(function () {
        $('#hoadon-lops').empty();
        var tong = 0;
        if ($('#hoadon-malop').val() != '') {
            var lops = $('#hoadon-malop').val().replace(' ', '').split(',');
            for (var i = 0; i < lops.length; i++) {
                malop = lops[i];
                $.ajax({
                    url: '/Lop/Tim',
                    data: { malop },
                    async: false,
                    method: 'POST',
                    success: function (response) {
                        if (response.success) {
                            var html = $('#hoadon-lops').html();
                            html = html + '<tr><td>' + response.malop + '</td><td>' + response.thoigianhoc + '</td><td class="hocphi">' + Number(response.hocphi).toLocaleString() + ' vnđ</td></tr>';
                            $('#hoadon-lops').html(html);
                            tong = tong + parseFloat(response.hocphi);
                        }
                        else {
                            $('#hoadon-lops').empty();
                            alert("Không tìm thấy lớp " + malop);
                            tong = 0;
                            return false;
                        }
                    }, error: function () {
                    }
                });
            }
        }
        if ($('#hoadon-madk').val() != '') { 
            var dks = $('#hoadon-madk').val().replace(' ', '').split(',');
            for (var i = 0; i < dks.length; i++) {
                madk = dks[i];
                $.ajax({
                    url: '/DangKy/Tim',
                    data: { madk },
                    async: false,
                    method: 'POST',
                    success: function (response) {
                        if (response.success) {
                            var html = $('#hoadon-lops').html();
                            html = html + '<tr><td>' + response.malop + '</td><td>' + response.thoigianhoc + '</td><td class="hocphi">' + Number(response.hocphi).toLocaleString() + ' vnđ</td></tr>';
                            $('#hoadon-lops').html(html);
                            tong = tong + parseFloat(response.hocphi);
                        }
                        else {
                            $('#hoadon-lops').empty();
                            alert("Không tìm thấy đăng ký " + madk);
                            tong = 0;
                            return false;
                        }
                    }, error: function () {
                    }
                });
            }
        }        
        var html = $('#hoadon-lops').html();
        html = html + '<tr class="bg-info"><td colspan="2" class="text-right"><b>Tổng tiền</b></td><td id="tongtien">' + Number(tong).toLocaleString() + ' vnđ</td></tr>';
        $('#hoadon-lops').html(html);
    });
    $('#hoadon-madk').change(function () {
        $('#hoadon-lops').empty();
        var tong = 0;
        if ($('#hoadon-malop').val() != '') {
            var lops = $('#hoadon-malop').val().replace(' ', '').split(',');
            for (var i = 0; i < lops.length; i++) {
                malop = lops[i];
                $.ajax({
                    url: '/Lop/Tim',
                    data: { malop },
                    async: false,
                    method: 'POST',
                    success: function (response) {
                        if (response.success) {
                            var html = $('#hoadon-lops').html();
                            html = html + '<tr><td>' + response.malop + '</td><td>' + response.thoigianhoc + '</td><td class="hocphi">' + Number(response.hocphi).toLocaleString() + ' vnđ</td></tr>';
                            $('#hoadon-lops').html(html);
                            tong = tong + parseFloat(response.hocphi);
                        }
                        else {
                            $('#hoadon-lops').empty();
                            alert("Không tìm thấy lớp " + malop);
                            tong = 0;
                            return false;
                        }
                    }, error: function () {
                    }
                });
            }
        }
        if ($('#hoadon-madk').val() != '') {
            var dks = $('#hoadon-madk').val().replace(' ', '').split(',');
            for (var i = 0; i < dks.length; i++) {
                madk = dks[i];
                $.ajax({
                    url: '/DangKy/Tim',
                    data: { madk },
                    async: false,
                    method: 'POST',
                    success: function (response) {
                        if (response.success) {
                            var html = $('#hoadon-lops').html();
                            html = html + '<tr><td>' + response.malop + '</td><td>' + response.thoigianhoc + '</td><td class="hocphi">' + Number(response.hocphi).toLocaleString() + ' vnđ</td></tr>';
                            $('#hoadon-lops').html(html);
                            tong = tong + parseFloat(response.hocphi);
                        }
                        else {
                            $('#hoadon-lops').empty();
                            alert("Không tìm thấy đăng ký " + madk);
                            tong = 0;
                            return false;
                        }
                    }, error: function () {
                    }
                });
            }
        }
        var html = $('#hoadon-lops').html();
        html = html + '<tr class="bg-info"><td colspan="2" class="text-right"><b>Tổng tiền</b></td><td id="tongtien">' + Number(tong).toLocaleString() + ' vnđ</td></tr>';
        $('#hoadon-lops').html(html);
    });
    $('#laphd').submit(function (e) {
        $.ajax({
            url: '/HoaDon/LapHoaDon_2',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    location = '/HoaDon/Xem?hoadon=' + response.mahd;
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('#chuyenlop-mahv').change(function () {
        var mahv = this.value;
        $.ajax({
            url: '/HocVien/Tim',
            data: { mahv },
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    $('#chuyenlop-hocvien').html(response.tenhv + ' <i>(Số điện thoại: ' + response.sdt + ')</i>');
                }
                else {
                    alert("Không tìm thấy học viên có mã " + mahv);
                    $('#chuyenlop-hocvien').empty();
                }
            }, error: function () {
            }
        });
    });
    $('#chuyenlop-malopcu').change(function () {
        var malop = this.value;
        $.ajax({
            url: '/Lop/Tim',
            data: { malop },
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    $('#chuyenlop-lopcu').html(response.malop + '<br/> Thời gian học: ' + response.thoigianhoc);
                }
                else {
                    alert("Không tìm thấy lớp có mã " + malop);
                    $('#chuyenlop-lopcu').empty();
                }
            }, error: function () {
            }
        });
    });
    $('#chuyenlop-malopmoi').change(function () {
        var malop = this.value;
        $.ajax({
            url: '/Lop/Tim',
            data: { malop },
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    $('#chuyenlop-lopmoi').html(response.malop + '<br/> Thời gian học: ' + response.thoigianhoc);
                }
                else {
                    alert("Không tìm thấy lớp có mã " + malop);
                    $('#chuyenlop-lopmoi').empty();
                }
            }, error: function () {
            }
        });
    });
    $('#chuyenlop').submit(function (e) {
        $.ajax({
            url: '/ChuyenLop/YeuCauChuyen',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    alert("Đã chuyển lớp thành công!");
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('#baoluu').submit(function (e) {
        $.ajax({
            url: '/BaoLuu/YeuCauBaoLuu',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    alert("Đã bảo lưu thành công!");
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('#huy-baoluu').submit(function (e) {
        $.ajax({
            url: '/BaoLuu/Huy',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    alert("Đã hủy thành công!");
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('.chamdiem-chuyencan').change(function () {
        var form = $(this).parent().parent();        
        form.submit();
    });
    $('.chamdiem').submit(function (e) {
        $.ajax({
            url: '/Lop/ChamDiem_2',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('.chamdiem-cuoiky').change(function () {
        var form = $(this).parent().parent();
        form.submit();
    });
    $('.chamdiem').submit(function (e) {
        $.ajax({
            url: '/Lop/ChamDiem_2',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('.chamdiem').submit(function (e) {
        $.ajax({
            url: '/Lop/ChamDiem_2',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('.xoa-taikhoan').submit(function (e) {
        $.ajax({
            url: '/TaiKhoan/Xoa',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    alert("Đã xóa tài khoản thành công");
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('.doi-matkhau').click(function () {
        $('#them-tk').hide();
        var data = $(this).val().split('|');
        $('#doi-matkhau-matk').val(data[0]);
        $('#doi-matkhau-username').val(data[1]);
        $('#doi-matkhau').show();
    });
    $('#doi-matkhau').submit(function (e) {
        $.ajax({
            url: '/TaiKhoan/DoiMatKhau',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    alert("Đã đổi mật khẩu thành công");
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('#them-tk').submit(function (e) {
        $.ajax({
            url: '/TaiKhoan/Them',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    alert("Đã tạo tài khoản thành công");
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('#btn-botri-giaovien').click(function () {
        $('#btn-botri-giaovien').hide();
        $('#lop-giaovien').hide();
        $('#botri-giaovien').show();
    });
    $('#botri-giaovien').submit(function (e) {
        $.ajax({
            url: '/Lop/BoTriGiaoVien',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    alert("Đã thay đổi giáo viên thành công!");
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
    $('.capnhat-ch').click(function () {
        $('#them-ch').hide();
        $('#capnhat-ch').show();
        var data = $(this).val().split('|');
        $('#capnhat-ch-mach').val(data[0]);
        $('#capnhat-ch-giohoc').val(data[1]);
        $('#capnhat-ch-ngayhoc').val(data[2]);
    });
    $('#capnhat-ch').submit(function (e) {
        $.ajax({
            url: '/CaHoc/CapNhat',
            data: $(this).serialize(),
            async: false,
            method: 'POST',
            success: function (response) {
                if (response.success) {
                    alert("Đã cập nhật ca học thành công!");
                    location.reload();
                }
                else {
                    alert(response.msg);
                }
            }, error: function () {
            }
        });
        e.preventDefault();
    });
});