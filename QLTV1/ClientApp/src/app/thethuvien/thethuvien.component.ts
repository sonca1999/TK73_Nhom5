import { AppPage } from './../../../e2e/src/app.po';
import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ReferenceAst } from '@angular/compiler';
declare var $:any;

@Component({
  selector: 'app-thethuvien',
  templateUrl: './thethuvien.component.html',
  styleUrls: ['./thethuvien.component.css']
})
export class ThethuvienComponent implements OnInit {

  thethuvien:any ={
    data:[],
    totalRecord:0,
    page:0,
    size:4,
    totalPage:0
  };

  thethuvien1:any ={
    maThe:0,
    ngayBd:"2020-04-21T18:25:43-05:00",
    ngayHh:"2020-04-25T18:25:43-05:00",
    ghiChu:"new1"
  };

  isEdit: boolean = true;

  constructor(
    private http: HttpClient, @Inject('BASE_URL') baseUrl: string
  ) { }

  ngOnInit() {
    this.searchThethuvien(1);
  }

  searchThethuvien(cPage){
    let x = {
      page:cPage,
      size:4,
      keyword:""
    }
    this.http.post('https://localhost:44304/'​+'api/Thethuvien/search-the-thu-vien', x).subscribe(result => {
      this.thethuvien = result;
      this.thethuvien = this.thethuvien.data;
      console.log(this.thethuvien);
    }, error => console.error(error));
  }

  searchNext(){
    if(this.thethuvien.page < this.thethuvien.totalPage){
      let nextPage = this.thethuvien.page + 1;
      let x = {
        page:nextPage,
        size:4,
        keyword:""
      }
      this.http.post('https://localhost:44304/'​+'api/Thethuvien/search-the-thu-vien', x).subscribe(result => {
        this.thethuvien = result;
        this.thethuvien = this.thethuvien.data;
        console.log(this.thethuvien);
      }, error => console.error(error));
    }
    else{
      alert("Bạn đang ở trang cuối cùng!");
    }
  }

  searchPrevious(){
    if(this.thethuvien.page > 1){
      let previousPage = this.thethuvien.page - 1;
      let x = {
        page:previousPage,
        size:4,
        keyword:""
      }
      this.http.post('https://localhost:44304/'​+'api/Thethuvien/search-the-thu-vien', x).subscribe(result => {
        this.thethuvien = result;
        this.thethuvien = this.thethuvien.data;
        console.log(this.thethuvien);
      }, error => console.error(error));
    }
    else{
      alert("Bạn đang ở trang đầu tiên!");
    }
  }

  openModal(isNew,index)
  {
    if(isNew)
    {
      this.isEdit = false;
      this.thethuvien1 ={
        maThe:0,
        ngayBd:"",
        ngayHh:"",
        ghiChu:""
      }
    }
    else
    {
      this.isEdit = true;
      this.thethuvien1 = this.thethuvien.data[index];
    }
    $('#exampleModal').modal("show");
  }

  addThethuvien()
  {
    var x = this.thethuvien1;
    this.http.post('https://localhost:44304/'​+'api/Thethuvien/create-the-thu-vien',x).subscribe(result => {
        var res:any = result;
        if(res.success)
        {
          this.thethuvien1 = res.data;
          this.isEdit = true;
          this.searchThethuvien(1);
          alert("Thẻ thư viện mới đã được tạo thành công!");
        }
      }, error => console.error(error));
    }

  updateThethuvien()
  {
    var x = this.thethuvien1;
    this.http.post('https://localhost:44304/api/Thethuvien/update-the-thu-vien',x).subscribe(result => {
        var res:any = result;
        if(res.success)
        {
          this.thethuvien1 = res.data;
          this.isEdit = true;
          this.searchThethuvien(1);
          alert("Thông tin thẻ thư viện đã được thay đổi thành công!");
        }
      }, error => console.error(error));
    }

  deleteThethuvien(index)
  {
    var r = confirm("Bạn có chắc chắn xóa?");
    if (r==true)
    {
      this.thethuvien1 = this.thethuvien.data[index];
      var x = this.thethuvien1;
      this.http.post('https://localhost:44304/' + 'api/Thethuvien/delete-the-thu-vien/', x)
      .subscribe(result => {
        var res:any = result;
        if(res.success)
        {
          this.searchThethuvien(1);
          alert("Đã xóa thành công!");
        }
        else {
          alert(res.message);
        }
    }, error => {
      console.error(error);
      alert(error);
    });
    }
  }

}


