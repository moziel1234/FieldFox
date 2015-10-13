function supTitle( title )
%SUPTITLE Summary 
%   Super title on subplots figure
    axes('Position',[0 0 1 1],'Xlim',[0 1],'Ylim',[0 1],'Box','off','Visible','off','Units','normalized', 'clipping' , 'off');

    text(0.5, 1,title,'HorizontalAlignment' ,'center','VerticalAlignment', 'top')

end

