import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $:any;

@Component({
  selector: 'app-ctmuontra',
  templateUrl: './ctmuontra.component.html',
  styleUrls: ['./ctmuontra.component.css']
})
export class CtmuontraComponent implements OnInit {

  ctmuontra: any={
    data:[],
    totalRecord:0,
    page:0,
    size:4,
    totalPage:0
  };

  ctmuontra1: any ={
    maSach:1,
    maMt:1,
    daTra:true,
    ngaytra:"2019-02-15" 
  };
  isEdit: boolean=true;
  

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') baseUrl: string) {}
    
  ngOnInit() {
    this.searchctmuontra(1);
  }

  searchctmuontra(cPage){
    let x ={
      page:cPage,
      size:4,
      keyword:""
    }
    this.http.post('https://localhost:44304/api/Ctmuontra/search-chi-tiet-muon-tra',x).subscribe(result => {
      this.ctmuontra = result;
      this.ctmuontra = this.ctmuontra.data;
      
    }, error => console.error(error));
  }
  searchNext(){
    
    if(this.ctmuontra.page<this.ctmuontra.totalPage){
      let nextPage =this.ctmuontra.page + 1;
      let x ={
        page:nextPage,
        size:4,
        keyword:""
      }
      this.http.post('https://localhost:44304/api/Ctmuontra/search-chi-tiet-muon-tra',x).subscribe(result => {
        this.ctmuontra = result;
        this.ctmuontra = this.ctmuontra.data;
      }, error => console.error(error));
    }
    else(alert("Bạn đang ở trang cuối !!!!"))
  }
  searchPrevious(){
    if(this.ctmuontra.page>1){
      let nextPage = this.ctmuontra.page - 1;
      let x ={
        page:nextPage,
        size:4,
        keyword:""
      }
      this.http.post('https://localhost:44304/api/Ctmuontra/search-chi-tiet-muon-tra',x).subscribe(result => {
        this.ctmuontra = result;
        this.ctmuontra = this.ctmuontra.data;
      }, error => console.error(error));
    }
    else(alert("Bạn đang ở trang đầu tiên !!!!"))
  }
  openModal(isNew,index)
  {
    if(isNew)
    {
      this.isEdit= false;
        this.ctmuontra1 ={
        maSach:1,
        maMt:0,
        daTra:true,
        ngaytra:""
      }
    }
    else{
      this.isEdit = true;
      this.ctmuontra1 =this.ctmuontra.data[index];
    }
    $('#exampleModal').modal("show");
  }
  addctmuontra()
  {
    var x = this.ctmuontra1;
    this.http.post("https://localhost:44304/api/Ctmuontra/create-chi-tiet-muon-tra",x).subscribe(result=>{
      var res:any =result;
      if(res.success){
        this.ctmuontra1 = res.data;
        this.isEdit = true;}
        this.searchctmuontra(1);
        alert("Bạn đã tạo thành công");
    },error=>console.error(error));}
  updatectmuontra()
  {
    var x =this.ctmuontra1;
    this.http.post("https://localhost:44304/api/Ctmuontra/create-chi-tiet-muon-tra",x).subscribe(result=>{
      var res:any =result;
      if(res.success)
      {
        this.ctmuontra1 = res.data;
        this.isEdit = true;}
        this.searchctmuontra(1);
        alert("Bạn đã cập nhật thành công");
    }, error=>console.error(error));
  }
  deleteCtmuontra(index)
  {
    var r = confirm("Bạn muốn xóa nó chứ?");
    if (r==true)
    {
      this.ctmuontra1 = this.ctmuontra.data[index];
      var x = this.ctmuontra1;
      this.http.post('https://localhost:44304/api/Ctmuontra/delete-chi-tiet-muon-tra', x)
      .subscribe(result => {
        var res:any = result;
        if(res.success)
        {
          this.searchctmuontra(1);
          alert("Bạn đã xóa thành công");
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
  

