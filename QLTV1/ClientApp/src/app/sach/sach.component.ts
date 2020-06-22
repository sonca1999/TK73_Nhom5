import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $: any;

@Component({
  selector: 'app-sach',
  templateUrl: './sach.component.html',
  styleUrls: ['./sach.component.css']
})
export class SachComponent implements OnInit {
  sach: any = {
    data: [],
    totalRecord: 0,
    page: 0,
    size: 4,
    totalPage: 0
  };
  sachs: any = {
    maSach: 1,
    tenSach: "Dac Nhan Tam",
    maTg: 1,
    maTl: 1,
    namSx: "2020-06-19T14:21:05.239Z"
  };
  isEdit: boolean = true;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string

  ) { }

  ngOnInit() {
    this.searchsach(1);
  }
  searchsach(cPage) {
    let x = {
      page: cPage,
      size: 4,
      keyword: " "
    }
    this.http.post('https://localhost:44304/api/Sach/search-sach', x).subscribe(result => {
      this.sach = result;
      this.sach = this.sach.data;
    }, error => console.error(error));
  }

  searchNext() {
    if (this.sach.page < this.sach.totalPage) {
      let nextPage = this.sach.page + 1;
      let x = {
        page: nextPage,
        size: 4,
        keyword: " "
      }
      this.http.post('https://localhost:44304/api/Sach/search-sach', x).subscribe(result => {
        this.sach = result;
        this.sach = this.sach.data;

      }, error => console.error(error));
    }
    else {
      alert("Bạn đang ở trang cuối !!!!");
    }
  }

  searchPrevious() {
    if (this.sach.page > 1) {
      let nextPage = this.sach.page - 1;
      let x = {
        page: nextPage,
        size: 2,
        keyword: " "
      }
      this.http.post('https://localhost:44304/api/Sach/search-sach', x).subscribe(result => {
        this.sach = result;
        this.sach = this.sach.data;

      }, error => console.error(error));
    }

    else {
      alert("Bạn đang ở trang đầu tiên !!!!");
    }
  }
  openModal(isNew, index) {
    if (isNew) {
      this.isEdit = false;
      this.sachs = {
        maSach: 0,
        tenSach: "",
        maTg: 1,
        maTl: 1,
        namSx: ""

      }
    }
    else {
      this.isEdit = true;
      this.sachs = this.sach.data[index];
    }
    $('#exampleModal').modal("show");

  }
  addsach() {
    var x = this.sachs;
    this.http.post('https://localhost:44304/api/Sach/create-sach', x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.sachs = res.data;
        this.isEdit = true;
        this.searchsach(1);
        alert("Bạn đã tạo Sách thành công");
      }
    }, error => console.error(error));
  }
  updatesach() {
    var x = this.sachs;
    this.http.post('https://localhost:44304/api/Sach/update-sach', x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.sachs = res.data;
        this.isEdit = true;
        this.searchsach(1);
        alert("Bạn đã cập nhật Sách thành công");
      }
    }, error => console.error(error));
  }
  deletesach(index) {
    var r = confirm("Ban muon xoa sach nay");
    if (r == true) {
      this.sachs = this.sach.data[index];
      var x = this.sachs;
      this.http.post('https://localhost:44304/api/Sach/delete-sach', x).subscribe(result => {
        var res: any = result;
        if (res.success) {
          this.searchsach(1);
          alert("Bạn đã xoa Sách thành công");
        }
        else {
          alert(res.message);
        }
      }, error => {
        console.error(error);
        alert(error);
      }
      );
    }

  }
}







