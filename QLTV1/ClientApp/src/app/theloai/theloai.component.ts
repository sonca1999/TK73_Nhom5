import { AppPage } from './../../../e2e/src/app.po';
import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $:any;

@Component({
  selector: 'app-theloai',
  templateUrl: './theloai.component.html',
  styleUrls: ['./theloai.component.css']
})
export class TheloaiComponent implements OnInit {

  theloai:any ={
    data:[],
    totalRecord:0,
    page:0,
    size:4,
    totalPage:0
  };

  theloai1:any ={
    tenTl:"Giao Duc"
  };

  isEdit: boolean = true;

  constructor(
    private http: HttpClient, @Inject('BASE_URL') baseUrl: string
  ) { }

  ngOnInit() {
    this.searchTheLoai(1);
  }

  searchTheLoai(cPage){
    let x = {
      page:cPage,
      size:4,
      keyword:""
    }
    this.http.post('https://localhost:44304/'​+'api/Theloai/search-the-loai', x).subscribe(result => {
      this.theloai = result;
      this.theloai = this.theloai.data;
      console.log(this.theloai);
    }, error => console.error(error));
  }

  searchNext(){
    if(this.theloai.page < this.theloai.totalPage){
      let nextPage = this.theloai.page + 1;
      let x = {
        page:nextPage,
        size:4,
        keyword:""
      }
      this.http.post('https://localhost:44304/'​+'api/Theloai/search-the-loai', x).subscribe(result => {
        this.theloai = result;
        this.theloai = this.theloai.data;
        console.log(this.theloai);
      }, error => console.error(error));
    }
    else{
      alert("Bạn đang ở trang cuối cùng!");
    }
  }

  searchPrevious(){
    if(this.theloai.page > 1){
      let previousPage = this.theloai.page - 1;
      let x = {
        page:previousPage,
        size:4,
        keyword:""
      }
      this.http.post('https://localhost:44304/'​+'api/Theloai/search-the-loai', x).subscribe(result => {
        this.theloai = result;
        this.theloai = this.theloai.data;
        console.log(this.theloai);
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
      this.theloai1 ={
        tenTl:""
      }
    }
    else
    {
      this.isEdit = true;
      this.theloai1 = this.theloai.data[index];
    }
    $('#exampleModal').modal("show");
  }

  addTheloai()
  {
    var x = this.theloai1;
    this.http.post('https://localhost:44304/'​+'api/Theloai/create-the-loai',x).subscribe(result => {
        var res:any = result;
        if(res.success)
        {
          this.theloai1 = res.data;
          this.isEdit = true;
          this.searchTheLoai(2);
          alert("Thể loại mới đã được tạo thành công!");
        }
      }, error => console.error(error));
    }

  updateTheloai()
  {
    var x = this.theloai1;
    this.http.post('https://localhost:44304/'​+'api/Theloai/update-the-loai',x).subscribe(result => {
        var res:any = result;
        if(res.success)
        {
          this.theloai1 = res.data;
          this.isEdit = true;
          this.searchTheLoai(2);
          alert("Thông tin thể loại đã được thay đổi thành công!");
        }
      }, error => console.error(error));
    }

  deleteTheloai(index)
  {
    var r = confirm("Bạn có chắc chắn xóa?");
    if (r==true)
    {
      this.theloai1 = this.theloai.data[index];
      var x = this.theloai1;
      this.http.post('https://localhost:44304/' + 'api/Theloai/delete-the-loai/', x)
      .subscribe(result => {
        var res:any = result;
        if(res.success)
        {
          this.searchTheLoai(1);
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
