import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { VideoCreateComponent } from './video-create.component';


describe('VideoCreateComponent', () => {
  let component: VideoCreateComponent;
  let fixture: ComponentFixture<VideoCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VideoCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VideoCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
