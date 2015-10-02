close all;

D = dir('C:\\FieldFox\*_*');
S = sort({D.name});
ind = 0;
times = zeros(size(S));
for folder_name = S
  disp(folder_name);
  obj = folderToObject(['C:\\FieldFox\',folder_name{1}]);
  figure; 
  subplot(1,3,1); plot(obj.time_sec,((obj.amp_db(:,56)))); xlabel('Time [sec]'); ylabel('amp [dB]'); title(['amp for freq= ',num2str(obj.freqs(56))]); 
  subplot(1,3,2); plot(obj.freqs,std(obj.amp_db)); xlabel('Freq [MHz]'); ylabel('std [db]'); title('std for amp');
  subplot(1,3,3); plot(obj.freqs,std(obj.phase_deg)); xlabel('Freq [MHz]'); ylabel('std [db]'); title('std for phase');
  ha = axes('Position',[0 0 1 1],'Xlim',[0 1],'Ylim',[0 1],'Box','off','Visible','off','Units','normalized', 'clipping' , 'off');

    text(0.5, 1,folder_name{1},'HorizontalAlignment' ,'center','VerticalAlignment', 'top')
end